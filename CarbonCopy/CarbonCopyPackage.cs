﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using System.Windows.Forms;
using Zinc.CarbonCopy.LanguageSpecific;

namespace Zinc.CarbonCopy
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidCarbonCopyPkgString)]
    //[ProvideAutoLoad(UIContextGuids80.Debugging)]
    [ProvideAutoLoad("f1536ef8-92ec-443c-9ed7-fdadf150da82")]    
    public sealed class CarbonCopyPackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public CarbonCopyPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }



        /////////////////////////////////////////////////////////////////////////////
        // Overridden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Debug.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.guidCarbonCopyCmdSet, (int)PkgCmdIDList.cmdidCopyDeclaration);

                OleMenuCommand projectmenuItem = new OleMenuCommand(MenuItemCallback, menuCommandID);
                mcs.AddCommand(projectmenuItem);
                projectmenuItem.BeforeQueryStatus += menuCommand_BeforeQueryStatus;
            }
        }
        #endregion

        private void menuCommand_BeforeQueryStatus(object sender, EventArgs e)
        {
             OleMenuCommand menuCommand = sender as OleMenuCommand;
            if (menuCommand != null)
            {
                var dteInstance = (DTE)GetService(typeof(SDTE));
                menuCommand.Visible = dteInstance.Debugger.DebuggedProcesses.Count > 0;
            }
        }

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CopyDeclaration();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(String.Concat(ex.Message, ex.StackTrace));
            }
        }

        private void CopyDeclaration()
        {
            string variableName = null;
            try
            {
                variableName = GetSelectedVariable();
            }
            catch (InvalidExpressionException)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Make sure the object name is fully selected.", "Invalid object selected");
                return;
            }

            Clipboard.SetText(GenerateDeclaration(variableName));
        }

        private string GetSelectedVariable()
        {
            var dteInstance = (DTE)GetService(typeof(SDTE));
            var textDocument = (EnvDTE.TextDocument)dteInstance.ActiveDocument.Object(String.Empty);
            var selectedVariable = textDocument.Selection.Text;

            EnvDTE.Expression expression = dteInstance.Debugger.GetExpression(selectedVariable);

            if (!expression.IsValidValue)
            {
                throw new InvalidExpressionException(selectedVariable);
            }

            return selectedVariable;
        }

        private string GenerateDeclaration(string variableName)
        {
            var dteInstance = (DTE)GetService(typeof(SDTE));

            SetDefaultSettings(dteInstance);

            var variableDeclaration = VariableDeclarationFactory.CreateVariableDeclaration(dteInstance);

            return variableDeclaration.GetDeclaration(variableName);
        }

        private void SetDefaultSettings(DTE dteInstance)
        {
            DebuggerHelper.Debugger = dteInstance.Debugger;

            DebuggerHelper.KnownValues = new System.Collections.Generic.Dictionary<string, object>();

            ExpressionsHelper.LanguageSpecificExpressions = LanguageSpecificExpressionsFactory.CreateExpressions(dteInstance);

            ObjectInitializationFactory.Instantiator = LanguageSpecificObjectInitializationInstantiatorFactory.CreateInstantiator(dteInstance);

            SetIndentationSize(dteInstance);
        }

        private void SetIndentationSize(DTE dteInstance)
        {
            try
            {
                var textEditorProperties = dteInstance.get_Properties("TextEditor", "Basic");
                var indentSizeProperty = textEditorProperties.Item("IndentSize");
                Indentation.IdeIndentSize = Int32.Parse(indentSizeProperty.Value.ToString());
            }
            catch { }
        }
    }
}

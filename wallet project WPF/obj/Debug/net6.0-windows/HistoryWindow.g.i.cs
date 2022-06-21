﻿#pragma checksum "..\..\..\HistoryWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2B2251A3F11EE0DF58585C444AC91B33E1EA7E8C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using wallet_project_WPF;


namespace wallet_project_WPF {
    
    
    /// <summary>
    /// HistoryWindow
    /// </summary>
    public partial class HistoryWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\HistoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView transactionList;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\HistoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox categoryComboBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\HistoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton proceedButton;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\HistoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton expenseButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\HistoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceFrom;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\HistoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceTo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/wallet project WPF;V1.0.0.0;component/historywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\HistoryWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.transactionList = ((System.Windows.Controls.ListView)(target));
            
            #line 15 "..\..\..\HistoryWindow.xaml"
            this.transactionList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.categoryComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\..\HistoryWindow.xaml"
            this.categoryComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CategoriesChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.proceedButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.expenseButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.priceFrom = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\HistoryWindow.xaml"
            this.priceFrom.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.priceFrom_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.priceTo = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\HistoryWindow.xaml"
            this.priceTo.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.priceTo_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

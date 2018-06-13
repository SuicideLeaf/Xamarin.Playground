// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PullToRefresh.iOS
{
    [Register ("DynamicViewController")]
    partial class DynamicViewController
    {
        [Outlet]
        UIKit.UITableView DynamicTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DynamicTableView != null) {
                DynamicTableView.Dispose ();
                DynamicTableView = null;
            }
        }
    }
}
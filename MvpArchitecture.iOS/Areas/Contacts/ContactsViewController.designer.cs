// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MvpArchitecture.iOS.Areas.Contacts
{
    [Register ("ContactsViewController")]
    partial class ContactsViewController
    {
        [Outlet]
        UIKit.UIView ErrorContainer { get; set; }


        [Outlet]
        UIKit.UILabel ErrorLabel { get; set; }


        [Outlet]
        UIKit.UIView LoadingContainer { get; set; }


        [Outlet]
        UIKit.UILabel LoadingLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ErrorContainer != null) {
                ErrorContainer.Dispose ();
                ErrorContainer = null;
            }

            if (ErrorLabel != null) {
                ErrorLabel.Dispose ();
                ErrorLabel = null;
            }

            if (LoadingContainer != null) {
                LoadingContainer.Dispose ();
                LoadingContainer = null;
            }

            if (LoadingLabel != null) {
                LoadingLabel.Dispose ();
                LoadingLabel = null;
            }
        }
    }
}
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
    [Register ("ContactsTableViewCell")]
    partial class ContactsTableViewCell
    {
        [Outlet]
        UIKit.UILabel ContactName { get; set; }


        [Outlet]
        UIKit.UILabel ContactTypes { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ContactName != null) {
                ContactName.Dispose ();
                ContactName = null;
            }

            if (ContactTypes != null) {
                ContactTypes.Dispose ();
                ContactTypes = null;
            }
        }
    }
}
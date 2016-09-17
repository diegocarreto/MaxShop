using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Extensions;

namespace PosUtilities
{
    public static class PosLabels
    {
        public static string GroupConfirmDelete1
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupConfirmDelete1"); }
        }

        public static string GroupConfirmDelete2
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupConfirmDelete2"); }
        }

        public static string GroupAlertError1
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupAlertError1"); }
        }

        public static string GroupAlertError2
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupAlertError2"); }
        }

        public static string GroupEditAlertPrefix
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupEditAlertPrefix"); }
        }

        public static string GroupEditAlertName
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupEditAlertName"); }
        }


        public static string GroupEditAlertExistGroupName1
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupEditAlertExistGroupName1"); }
        }

        public static string GroupEditAlertExistGroupName2
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupEditAlertExistGroupName2"); }
        }

        public static string GroupEditAlertExistGroupPrefix1
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupEditAlertExistGroupPrefix1"); }
        }

        public static string GroupEditAlertExistGroupPrefix2
        {
            get { return eObject.AppSet<string>(string.Empty, "GroupEditAlertExistGroupPrefix2"); }
        }
    }
}

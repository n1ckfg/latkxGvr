using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr.Internal;

// GVR apps don't use the standard Android manifest method of setting permissions.

namespace GoogleVR.PermissionsDemo {

    public class SetManifestPermissions : MonoBehaviour {

        private string[] permissionNames = {
        "READ_EXTERNAL_STORAGE",
        "CAMERA",
        "RECORD_AUDIO",
        "READ_EXTERNAL_STORAGE",
        "WRITE_EXTERNAL_STORAGE",
        "READ_INTERNAL_STORAGE",
        "WRITE_INTERNAL_STORAGE",
        "INTERNET",
        "ACCESS_NETWORK_STATE",
        "GET_ACCOUNTS"
    };

        private List<GvrPermissionsRequester.PermissionStatus> permissionList = new List<GvrPermissionsRequester.PermissionStatus>();

        private void Start() {
            for (int i = 0; i < permissionNames.Length; i++) {
                permissionNames[i] = "android.permission." + permissionNames[i];
            }
            GvrPermissionsRequester permissionRequester = GvrPermissionsRequester.Instance;
            permissionRequester.RequestPermissions(permissionNames,
                (GvrPermissionsRequester.PermissionStatus[] permissionResults) => {
                    permissionList.Clear();
                    permissionList.AddRange(permissionResults);
                    string msg = "";
                    foreach (GvrPermissionsRequester.PermissionStatus p in permissionList) {
                        msg += p.Name + ": " + (p.Granted ? "Granted" : "Denied") + "\n";
                    }

                    Debug.Log(msg);
                });
        }

    }

}

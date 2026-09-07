using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnableBramShuttle
{
    [HarmonyPatch(typeof(ElevatorWindow), nameof(ElevatorWindow.Configure))]
    public static class EnableHellivatorCargoAccess
    {
        public static void Postfix(ElevatorWindow __instance)
        {
            //Plugin.Logger.Log("--- main menu awake");

            if (__instance._shuttleCargoButton != null)
            {
                ShuttleCargoDepartment department = __instance._magnumSpaceship.GetDepartment<ShuttleCargoDepartment>();
                __instance._shuttleCargoButton.gameObject.SetActive(department != null && department.IsActiveDepartment());
            }

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
    public class Notification : MonoBehaviour
    {
        private void Start()
        {
            ScheduleNormal();
        }

        public void ScheduleNormal()
        {
            NotificationManager.SendWithAppIcon(TimeSpan.FromHours(8), "KNIFE HIT", "WE ARE MISSING YOU",
                new Color(0, 0.6f, 1), NotificationIcon.Message);
        }
    }
}
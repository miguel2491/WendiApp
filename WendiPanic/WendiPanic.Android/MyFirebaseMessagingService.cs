using Android.App;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using Android.Util;
using Firebase.Messaging;
using System.Collections.Generic;

namespace WendiPanic.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService //, IOnRing...
    {
        const string TAG = "MyFirebaseMsgService";
        Ringtone r;
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);
            //aqui debe ser 
            var body = message.GetNotification().Body;
            Log.Debug(TAG, "Notification Message Body: " + body);
            //handler = OnRingEvent;
            SendNotification(body, message.Data);
        }
        //OnRingEEvet(){  r.llamarsonid(uri) }
        void SendNotification(string messageBody, IDictionary<string, string> data)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            foreach (var key in data.Keys)
            {
                intent.PutExtra(key, data[key]);
            }

            var pendingIntent = PendingIntent.GetActivity(this, MainActivity.NOTIFICATION_ID, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
                                      .SetSmallIcon(Resource.Drawable.ic_mtrl_chip_checked_black)
                                      .SetContentTitle("FCM Message")
                                      .SetContentText(messageBody)
                                      .SetAutoCancel(true)
                                      .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManagerCompat.From(this);


            notificationManager.Notify(MainActivity.NOTIFICATION_ID, notificationBuilder.Build());
            // send ring 
            /*
             MessangerCenter.Send<object>("onRingAlarm");
             */

            //opcion 2 
            //

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;

namespace Policem.UI.Core
{
    public static class OutlookTakvim
    {
        public static void CreateMeetingRequest(string toEmail, string subject, string body, DateTime startDate, DateTime endDate)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application objOL = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.AppointmentItem objAppt = (Microsoft.Office.Interop.Outlook.AppointmentItem)objOL.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
                objAppt.Start = startDate;
                objAppt.End = endDate;
                objAppt.AllDayEvent = true;
                objAppt.Subject = subject;
                objAppt.Body = body;
                //objAppt.Attachments.Add()
                objAppt.MeetingStatus = Microsoft.Office.Interop.Outlook.OlMeetingStatus.olMeeting;
                objAppt.RequiredAttendees = toEmail;
                objAppt.Send();
                objAppt = null;
                objOL = null;
        //    Microsoft.Office.Interop.Outlook.AppointmentItem agendaMeeting = 
        //        (Microsoft.Office.Interop.Outlook.AppointmentItem)this.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.
        //olAppointmentItem);

        //    if (agendaMeeting != null)
        //    {
        //        agendaMeeting.MeetingStatus =
        //            Microsoft.Office.Interop.Outlook.OlMeetingStatus.olMeeting;
        //        agendaMeeting.Location = "Conference Room";
        //        agendaMeeting.Subject = "Discussing the Agenda";
        //        agendaMeeting.Body = "Let's discuss the agenda.";
        //        agendaMeeting.Start = new DateTime(2005, 5, 5, 5, 0, 0);
        //        agendaMeeting.Duration = 60;
        //        Microsoft.Office.Interop.Outlook.Recipient recipient =
        //            agendaMeeting.Recipients.Add("Nate Sun");
        //        recipient.Type =
        //            (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType.olRequired;
        //        ((Microsoft.Office.Interop.Outlook._AppointmentItem)agendaMeeting).Send();
        //    }
            }
            catch { AppSession.MainForm.NotifyMain("Outlook Takvimi Oluşturulurken Hata Oluştu."); }
        }
    }
}

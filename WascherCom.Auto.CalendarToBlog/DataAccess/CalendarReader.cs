// -----------------------------------------------------------------------
// <copyright file="CalendarReader.cs" company="SoftSource Consulting">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WascherCom.Auto.CalendarToBlog.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Google.GData.Calendar;

    using WascherCom.Auto.CalendarToBlog.Entites;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CalendarReader
    {
        public const string GOOGLE_URI = "https://www.google.com/calendar/feeds/{0}/public/full";

        public CalendarReader()
        {
            DaysForPastEvents = 7;
            DaysForCurrentEvents = 7;
            DaysForFutureEvents = 7;
            StartDate = DateTime.Now;
        }

        public string UserId { get; set; }

        public string Password { get; set; }

        public int DaysForPastEvents { get; set; }

        public int DaysForCurrentEvents { get; set; }

        public int DaysForFutureEvents { get; set; }

        public DateTime StartDate { get; set; }

        public PostableEvents GetPostableEvents(string calendarId)
        {
            var result = new PostableEvents();

            var service = new CalendarService("WascherCom.Auto.CalendarToBlog");

            if (!string.IsNullOrWhiteSpace(UserId))
            {
                service.setUserCredentials(UserId, Password);
            }

            var query = new EventQuery
                {
                    Uri = new Uri(string.Format(GOOGLE_URI, calendarId)),
                    StartTime = StartDate.AddDays(-DaysForPastEvents),
                    EndTime = StartDate.AddDays(DaysForCurrentEvents + DaysForFutureEvents)
                };

            var eventFeed = service.Query(query);

            if (eventFeed == null || eventFeed.Entries.Count == 0)
            {
                return result;
            }

            foreach (EventEntry entry in eventFeed.Entries)
            {
                foreach (var time in entry.Times)
                {
                    var calEvent = new CalendarEvent
                        {
                            Title = entry.Title.Text,
                            Description = string.Empty,
                            StartDateTime = time.StartTime,
                            EndDateTime = time.EndTime,
                            IsAllDay = time.AllDay
                        };

                    if (calEvent.StartDateTime < StartDate)
                    {
                        result.PastEvents.Add(calEvent);
                    } 
                    else if (calEvent.StartDateTime > StartDate.AddDays(DaysForCurrentEvents))
                    {
                        result.FutureEvents.Add(calEvent);
                    }
                    else
                    {
                        result.CurrentEvents.Add(calEvent);
                    }

                    Console.WriteLine(string.Format("{0}: {1} All Day: {2}", entry.Title.Text, time.StartTime, time.AllDay));
                }
            }

            return result;
        }
    }
}

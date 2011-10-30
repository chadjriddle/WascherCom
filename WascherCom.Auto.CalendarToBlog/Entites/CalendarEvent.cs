// -----------------------------------------------------------------------
// <copyright file="CalendarEvent.cs" company="chadjriddle">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WascherCom.Auto.CalendarToBlog.Entites
{
    using System;

    /// <summary>
    /// Parsed Calendar Event 
    /// </summary>
    public class CalendarEvent
    {
        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsWeekly.
        /// </summary>
        public bool IsWeekly { get; set; }

        /// <summary>
        /// Gets or sets StartDateTime.
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets EndDateTime.
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsAllDay.
        /// </summary>
        public bool IsAllDay { get; set; }
    }
}

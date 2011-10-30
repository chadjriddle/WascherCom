// -----------------------------------------------------------------------
// <copyright file="PostableEvents.cs" company="chadjriddle">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WascherCom.Auto.CalendarToBlog.Entites
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains references to all events that will be included in the Blog post
    /// </summary>
    public class PostableEvents
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostableEvents"/> class.
        /// </summary>
        public PostableEvents()
        {
            PastEvents = new List<CalendarEvent>();
            CurrentEvents = new List<CalendarEvent>();
            FutureEvents = new List<CalendarEvent>();
        }

        /// <summary>
        /// Gets PastEvents.
        /// </summary>
        public List<CalendarEvent> PastEvents { get; private set; }

        /// <summary>
        /// Gets CurrentEvents.
        /// </summary>
        public List<CalendarEvent> CurrentEvents { get; private set; }

        /// <summary>
        /// Gets FutureEvents.
        /// </summary>
        public List<CalendarEvent> FutureEvents { get; private set; }
    }
}

/*
Template Name: Konrix - Responsive 5 Admin Dashboard
Author: CoderThemes
Website: https://coderthemes.com/
Contact: support@coderthemes.com
File: Calendar js
*/

class Calendar {

     constructor() {
         this.body = document.body;
         this.calendar = document.getElementById('calendar');
         this.formEvent = document.getElementById('forms-event');
         this.btnNewEvent = document.getElementById('btn-new-event');
         this.btnDeleteEvent = document.getElementById('btn-delete-event');
         this.btnSaveEvent = document.getElementById('btn-save-event');
         this.calendarObj = null;
         this.selectedEvent = null;
         this.newEventData = null;
     }
 
     onEventClick(info) {
         this.formEvent?.reset();
         this.formEvent.classList.remove('was-validated');
         this.newEventData = null;
         this.btnDeleteEvent.style.display = "block";
         this.selectedEvent = info.event;
         document.getElementById('event-title').value = this.selectedEvent.title;
         document.getElementById('event-category').value = (this.selectedEvent.classNames[0]);
     }
 
     init() {
         /*  Initialize the calendar  */
         const today = new Date();
         const self = this;
         const externalEventContainerEl = document.getElementById('external-events');
 
         new FullCalendar.Draggable(externalEventContainerEl, {
             itemSelector: '.external-event',
             eventData: function (eventEl) {
                 return {
                     title: eventEl.innerText,
                     classNames: eventEl.getAttribute('data-class')
                 };
             }
         });
 
         const defaultEvents = [{
             title: 'مصاحبه - مهندس پشتیبانی',
             start: today,
             end: today,
             className: 'bg-primary'
         },
         {
             title: 'ملاقات با تیم CT',
             start: new Date(Date.now() + 13000000),
             end: today,
             className: 'bg-warning'
         },
         {
             title: 'ملاقات با آقای شیلد',
             start: new Date(Date.now() + 308000000),
             end: new Date(Date.now() + 338000000),
             className: 'bg-info'
         },
         {
             title: 'مصاحبه - مهندس رابط کاربری',
             start: new Date(Date.now() + 60570000),
             end: new Date(Date.now() + 153000000),
             className: 'bg-secondary'
         },
         {
             title: 'اسکرین تلفنی - مهندس رابط کاربری',
             start: new Date(Date.now() + 168000000),
             className: 'bg-success'
         },
         {
             title: 'خرید دارایی‌های طراحی',
             start: new Date(Date.now() + 330000000),
             end: new Date(Date.now() + 330800000),
             className: 'bg-primary',
         },
         {
             title: 'راه‌اندازی مخزن Github',
             start: new Date(Date.now() + 1008000000),
             end: new Date(Date.now() + 1108000000),
             className: 'bg-danger'
         },
         {
             title: 'ملاقات با آقای شریو',
             start: new Date(Date.now() + 2508000000),
             end: new Date(Date.now() + 2508000000),
             className: 'bg-dark'
         }
     ];
     
 
         // cal - init
         self.calendarObj = new FullCalendar.Calendar(self.calendar, {
 
             plugins: [],
             slotDuration: '00:30:00', /* If we want to split day time each 15minutes */
             slotMinTime: '07:00:00',
             slotMaxTime: '19:00:00',
             themeSystem: 'default',
             initialView: 'dayGridMonth',
             locale: 'fa',
             handleWindowResize: true,
             height: window.innerHeight - 300,
             headerToolbar: {
                 left: 'prev,next today',
                 center: 'title',
                 right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
             },
             initialEvents: defaultEvents,
             editable: true,
             droppable: true, // this allows things to be dropped onto the calendar !!!
             // dayMaxEventRows: false, // allow "more" link when too many events
             selectable: true,
           
             eventClick: function (info) {
                 self.onEventClick(info);
             }
         });
 
         self.calendarObj.render();
     }
 
 }
 document.addEventListener('DOMContentLoaded', function (e) {
     new Calendar().init();
 });
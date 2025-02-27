/*
نام الگو: Larkon - داشبورد مدیریتی واکنش‌گرا ۵
نویسنده: Techzaa
فایل: datatable js
*/

class GridDatatable {

     init() {
          this.GridjsTableInit();
     }

     GridjsTableInit() {

          // جدول ساده
          if (document.getElementById("table-gridjs"))
               new gridjs.Grid({
                    language:gridjs.l10n.faIR,
                    columns: [{
                         name: 'شناسه',
                         formatter: (function (cell) {
                              return gridjs.html('<span class="fw-semibold">' + cell + '</span>');
                         })
                    },
                         "نام",
                    {
                         name: 'ایمیل',
                         formatter: (function (cell) {
                              return gridjs.html('<a href="">' + cell + '</a>');
                         })
                    },
                         "سمت", "شرکت", "کشور",
                    {
                         name: 'عملیات',
                         width: '120px',
                         formatter: (function (cell) {
                              return gridjs.html("<a href='#' class='text-reset text-decoration-underline'>" + "جزئیات" + "</a>");
                         })
                    },
                    ],
                    pagination: {
                         limit: 5
                    },
                    sort: true,
                    search: true,
                    data: [
                         ["11", "آلیس", "alice@example.com", "مهندس نرم‌افزار", "شرکت ABC", "ایالات متحده"],
                         ["12", "باب", "bob@example.com", "مدیر محصول", "شرکت XYZ", "کانادا"],
                         ["13", "چارلی", "charlie@example.com", "تحلیل‌گر داده", "شرکت 123", "استرالیا"],
                         ["14", "دیوید", "david@example.com", "طراحی UI/UX", "شرکت 456", "بریتانیا"],
                         ["15", "اوا", "eve@example.com", "متخصص بازاریابی", "شرکت 789", "فرانسه"],
                         ["16", "فرانک", "frank@example.com", "مدیر منابع انسانی", "شرکت ABC", "آلمان"],
                         ["17", "گریس", "grace@example.com", "تحلیل‌گر مالی", "شرکت XYZ", "ژاپن"],
                         ["18", "هانا", "hannah@example.com", "نماینده فروش", "شرکت 123", "برزیل"],
                         ["19", "ایان", "ian@example.com", "توسعه‌دهنده نرم‌افزار", "شرکت 456", "هند"],
                         ["20", "جین", "jane@example.com", "مدیر عملیات", "شرکت 789", "چین"]
                    ]
               }).render(document.getElementById("table-gridjs"));

          // جدول با صفحه‌بندی
          if (document.getElementById("table-pagination"))
               new gridjs.Grid({
                    language:gridjs.l10n.faIR,
                    columns: [{
                         name: 'شناسه',
                         width: '120px',
                         formatter: (function (cell) {
                              return gridjs.html('<a href="" class="fw-medium">' + cell + '</a>');
                         })
                    }, "نام", "تاریخ", "مجموع",
                    {
                         name: 'عملیات',
                         width: '100px',
                         formatter: (function (cell) {
                              return gridjs.html("<button type='button' class='btn btn-sm btn-light'>" +
                                   "جزئیات" +
                                   "</button>");
                         })
                    },
                    ],
                    pagination: {
                         limit: 5
                    },

                    data: [
                         ["#RB2320", "آلیس", "07 اکتبر 2024", "$24.05"],
                         ["#RB8652", "باب", "07 اکتبر 2024", "$26.15"],
                         ["#RB8520", "چارلی", "06 اکتبر 2024", "$21.25"],
                         ["#RB9512", "دیوید", "05 اکتبر 2024", "$25.03"],
                         ["#RB7532", "اوا", "05 اکتبر 2024", "$22.61"],
                         ["#RB9632", "فرانک", "04 اکتبر 2024", "$24.05"],
                         ["#RB7456", "گریس", "04 اکتبر 2024", "$26.15"],
                         ["#RB3002", "هانا", "04 اکتبر 2024", "$21.25"],
                         ["#RB9857", "ایان", "03 اکتبر 2024", "$22.61"],
                         ["#RB2589", "جین", "03 اکتبر 2024", "$25.03"],
                    ]
               }).render(document.getElementById("table-pagination"));

          // جدول جستجو
          if (document.getElementById("table-search"))
               new gridjs.Grid({
                    language:gridjs.l10n.faIR,
                    columns: ["نام", "ایمیل", "سمت", "شرکت", "کشور"],
                    pagination: {
                         limit: 5
                    },
                    search: true,
                    data: [
                         ["آلیس", "alice@example.com", "مهندس نرم‌افزار", "شرکت ABC", "ایالات متحده"],
                         ["باب", "bob@example.com", "مدیر محصول", "شرکت XYZ", "کانادا"],
                         ["چارلی", "charlie@example.com", "تحلیل‌گر داده", "شرکت 123", "استرالیا"],
                         ["دیوید", "david@example.com", "طراحی UI/UX", "شرکت 456", "بریتانیا"],
                         ["اوا", "eve@example.com", "متخصص بازاریابی", "شرکت 789", "فرانسه"],
                         ["فرانک", "frank@example.com", "مدیر منابع انسانی", "شرکت ABC", "آلمان"],
                         ["گریس", "grace@example.com", "تحلیل‌گر مالی", "شرکت XYZ", "ژاپن"],
                         ["هانا", "hannah@example.com", "نماینده فروش", "شرکت 123", "برزیل"],
                         ["ایان", "ian@example.com", "توسعه‌دهنده نرم‌افزار", "شرکت 456", "هند"],
                         ["جین", "jane@example.com", "مدیر عملیات", "شرکت 789", "چین"]
                    ]
               }).render(document.getElementById("table-search"));

          // جدول مرتب‌سازی
          if (document.getElementById("table-sorting"))
               new gridjs.Grid({
                    language:gridjs.l10n.faIR,
                    columns: ["نام", "ایمیل", "سمت", "شرکت", "کشور"],
                    pagination: {
                         limit: 5
                    },
                    sort: true,
                    data: [
                         ["آلیس", "alice@example.com", "مهندس نرم‌افزار", "شرکت ABC", "ایالات متحده"],
                         ["باب", "bob@example.com", "مدیر محصول", "شرکت XYZ", "کانادا"],
                         ["چارلی", "charlie@example.com", "تحلیل‌گر داده", "شرکت 123", "استرالیا"],
                         ["دیوید", "david@example.com", "طراحی UI/UX", "شرکت 456", "بریتانیا"],
                         ["اوا", "eve@example.com", "متخصص بازاریابی", "شرکت 789", "فرانسه"],
                         ["فرانک", "frank@example.com", "مدیر منابع انسانی", "شرکت ABC", "آلمان"],
                         ["گریس", "grace@example.com", "تحلیل‌گر مالی", "شرکت XYZ", "ژاپن"],
                         ["هانا", "hannah@example.com", "نماینده فروش", "شرکت 123", "برزیل"],
                         ["ایان", "ian@example.com", "توسعه‌دهنده نرم‌افزار", "شرکت 456", "هند"],
                         ["جین", "jane@example.com", "مدیر عملیات", "شرکت 789", "چین"]
                    ]
               }).render(document.getElementById("table-sorting"));


          // جدول حالت بارگذاری
          if (document.getElementById("table-loading-state"))
               new gridjs.Grid({
                    language:gridjs.l10n.faIR,
                    columns: ["نام", "ایمیل", "سمت", "شرکت", "کشور"],
                    pagination: {
                         limit: 5
                    },
                    sort: true,
                    data: function () {
                         return new Promise(function (resolve) {
                              setTimeout(function () {
                                   resolve([
                                        ["آلیس", "alice@example.com", "مهندس نرم‌افزار", "شرکت ABC", "ایالات متحده"],
                                        ["باب", "bob@example.com", "مدیر محصول", "شرکت XYZ", "کانادا"],
                                        ["چارلی", "charlie@example.com", "تحلیل‌گر داده", "شرکت 123", "استرالیا"],
                                        ["دیوید", "david@example.com", "طراحی UI/UX", "شرکت 456", "بریتانیا"],
                                        ["اوا", "eve@example.com", "متخصص بازاریابی", "شرکت 789", "فرانسه"],
                                        ["فرانک", "frank@example.com", "مدیر منابع انسانی", "شرکت ABC", "آلمان"],
                                        ["گریس", "grace@example.com", "تحلیل‌گر مالی", "شرکت XYZ", "ژاپن"],
                                        ["هانا", "hannah@example.com", "نماینده فروش", "شرکت 123", "برزیل"],
                                        ["ایان", "ian@example.com", "توسعه‌دهنده نرم‌افزار", "شرکت 456", "هند"],
                                        ["جین", "jane@example.com", "مدیر عملیات", "شرکت 789", "چین"]
                                   ])
                              }, 2000);
                         });
                    }
               }).render(document.getElementById("table-loading-state"));


          // سرصفحه ثابت
          if (document.getElementById("table-fixed-header"))
               new gridjs.Grid({
                    language:gridjs.l10n.faIR,
                    columns: ["نام", "ایمیل", "سمت", "شرکت", "کشور"],
                    sort: true,
                    pagination: true,
                    fixedHeader: true,
                    height: '400px',
                    data: [
                         ["آلیس", "alice@example.com", "مهندس نرم‌افزار", "شرکت ABC", "ایالات متحده"],
                         ["باب", "bob@example.com", "مدیر محصول", "شرکت XYZ", "کانادا"],
                         ["چارلی", "charlie@example.com", "تحلیل‌گر داده", "شرکت 123", "استرالیا"],
                         ["دیوید", "david@example.com", "طراحی UI/UX", "شرکت 456", "بریتانیا"],
                         ["اوا", "eve@example.com", "متخصص بازاریابی", "شرکت 789", "فرانسه"],
                         ["فرانک", "frank@example.com", "مدیر منابع انسانی", "شرکت ABC", "آلمان"],
                         ["گریس", "grace@example.com", "تحلیل‌گر مالی", "شرکت XYZ", "ژاپن"],
                         ["هانا", "hannah@example.com", "نماینده فروش", "شرکت 123", "برزیل"],
                         ["ایان", "ian@example.com", "توسعه‌دهنده نرم‌افزار", "شرکت 456", "هند"],
                         ["جین", "jane@example.com", "مدیر عملیات", "شرکت 789", "چین"]
                    ]
               }).render(document.getElementById("table-fixed-header"));


          // ستون‌های پنهان
          if (document.getElementById("table-hidden-column"))
               new gridjs.Grid({
                    language:gridjs.l10n.faIR,
                    columns: ["نام", "ایمیل", "سمت", "شرکت",
                         {
                              name: 'کشور',
                              hidden: true
                         },
                    ],
                    pagination: {
                         limit: 5
                    },
                    sort: true,
                    data: [
                         ["آلیس", "alice@example.com", "مهندس نرم‌افزار", "شرکت ABC", "ایالات متحده"],
                         ["باب", "bob@example.com", "مدیر محصول", "شرکت XYZ", "کانادا"],
                         ["چارلی", "charlie@example.com", "تحلیل‌گر داده", "شرکت 123", "استرالیا"],
                         ["دیوید", "david@example.com", "طراحی UI/UX", "شرکت 456", "بریتانیا"],
                         ["اوا", "eve@example.com", "متخصص بازاریابی", "شرکت 789", "فرانسه"],
                         ["فرانک", "frank@example.com", "مدیر منابع انسانی", "شرکت ABC", "آلمان"],
                         ["گریس", "grace@example.com", "تحلیل‌گر مالی", "شرکت XYZ", "ژاپن"],
                         ["هانا", "hannah@example.com", "نماینده فروش", "شرکت 123", "برزیل"],
                         ["ایان", "ian@example.com", "توسعه‌دهنده نرم‌افزار", "شرکت 456", "هند"],
                         ["جین", "jane@example.com", "مدیر عملیات", "شرکت 789", "چین"]
                    ]
               }).render(document.getElementById("table-hidden-column"));


     }

}

document.addEventListener('DOMContentLoaded', function (e) {
     new GridDatatable().init();
});
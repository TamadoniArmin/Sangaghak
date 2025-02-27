/**
 * تم: Larkon - داشبورد مدیریت پاسخ‌گو با Bootstrap 5
 * نویسنده: Techzaa
 * ماژول/برنامه: نمودارهای خطی Apex
 */

//
// نمودار خطی ساده
//
var colors = ["#7f56da"];
var options = {
  chart: {
    toolbar: {
      show: false,
    },
    height: 380,
    type: "line",
    zoom: {
      enabled: false,
    },
  },
  dataLabels: {
    enabled: false,
  },
  colors: colors,
  stroke: {
    width: [4],
    curve: "straight",
  },
  series: [
    {
      name: "رایانه‌های شخصی",
      data: [30, 41, 35, 51, 49, 62, 69, 91, 126],
    },
  ],
  title: {
    text: "ترندهای محصول بر اساس ماه",
    align: "center",
  },
  grid: {
    row: {
      colors: ["transparent", "transparent"], // می‌تواند آرایه‌ای باشد که در ستون‌ها تکرار می‌شود
      opacity: 0.2,
    },
    borderColor: "#f1f3fa",
  },
  labels: series.monthDataSeries1.dates,
  xaxis: {
    categories: ["دی", "بهمن", "اسفند", "فروردین", "اردیبهشت", "خرداد", "تیر" , "شهریور", "مهر"],
  },
  responsive: [
    {
      breakpoint: 600,
      options: {
        chart: {
          toolbar: {
            show: false,
          },
        },
        legend: {
          show: false,
        },
      },
    },
  ],
};

var chart = new ApexCharts(document.querySelector("#line-chart"), options);
chart.render();

//
// نمودار خطی با برچسب‌های داده
//

var colors = ["#ef5f5f", "#22c55e"];
var options = {
  chart: {
    height: 380,
    type: "line",
    zoom: {
      enabled: false,
    },
    toolbar: {
      show: false,
    },
  },
  colors: colors,
  dataLabels: {
    enabled: true,
  },
  stroke: {
    width: [3, 3],
    curve: "smooth",
  },
  series: [
    {
      name: "حداکثر - 1403",
      data: [28, 29, 33, 36, 32, 32, 33],
    },
    {
      name: "حداقل - 1403",
      data: [12, 11, 14, 18, 17, 13, 13],
    },
  ],
  title: {
    text: "دمای متوسط حداقل و حداکثر",
    align: "left",
  },
  grid: {
    row: {
      colors: ["transparent", "transparent"], // می‌تواند آرایه‌ای باشد که در ستون‌ها تکرار می‌شود
      opacity: 0.2,
    },
    borderColor: "#f1f3fa",
  },
  markers: {
    style: "inverted",
    size: 6,
  },
  xaxis: {
    categories: ["دی", "بهمن", "اسفند", "فروردین", "اردیبهشت", "خرداد", "تیر"],
    title: {
      text: "ماه",
    },
  },
  yaxis: {
    title: {
      text: "دمای",
    },
    min: 5,
    max: 40,
  },
  legend: {
    position: "top",
    horizontalAlign: "right",
    floating: true,
    offsetY: -25,
    offsetX: -5,
  },
  responsive: [
    {
      breakpoint: 600,
      options: {
        chart: {
          toolbar: {
            show: false,
          },
        },
        legend: {
          show: false,
        },
      },
    },
  ],
};
var chart = new ApexCharts(
  document.querySelector("#line-chart-datalabel"),
  options
);
chart.render();

//
// سری‌های زمانی قابل زوم
//

var ts2 = 1484418600000;
var dates = [];
var spikes = [5, -5, 3, -3, 8, -8];
for (var i = 0; i < 120; i++) {
  ts2 = ts2 + 86400000;
  var innerArr = [ts2, dataSeries[1][i].value];
  dates.push(innerArr);
}
var colors = ["#7f56da"];
var options = {
  chart: {
    toolbar: {
      show: false,
    },
    type: "area",
    stacked: false,
    height: 380,
    zoom: {
      enabled: true,
    },
  },
  plotOptions: {
    line: {
      curve: "smooth",
    },
  },
  dataLabels: {
    enabled: false,
  },
  stroke: {
    width: [3],
  },
  series: [
    {
      name: "موتورها",
      data: dates,
    },
  ],
  markers: {
    size: 0,
    style: "full",
  },
  colors: colors,
  title: {
    text: "حرکت قیمت سهام",
    align: "left",
  },
  grid: {
    row: {
      colors: ["transparent", "transparent"], // می‌تواند آرایه‌ای باشد که در ستون‌ها تکرار می‌شود
      opacity: 0.2,
    },
    borderColor: "#f1f3fa",
  },
  fill: {
    gradient: {
      enabled: true,
      shadeIntensity: 1,
      inverseColors: false,
      opacityFrom: 0.5,
      opacityTo: 0.1,
      stops: [0, 70, 80, 100],
    },
  },
  yaxis: {
    min: 20000000,
    max: 250000000,
    labels: {
      formatter: function (val) {
        return (val / 1000000).toFixed(0);
      },
    },
    title: {
      text: "قیمت",
    },
  },
  xaxis: {
    type: "category",
    labels: {
      formatter: function() {
        return "1403"
      }
    }
  },

  tooltip: {
    shared: false,
    y: {
      formatter: function (val) {
        return (val / 1000000).toFixed(0);
      },
    },
  },
  responsive: [
    {
      breakpoint: 600,
      options: {
        chart: {
          toolbar: {
            show: false,
          },
        },
        legend: {
          show: false,
        },
      },
    },
  ],
};
var chart = new ApexCharts(
  document.querySelector("#line-chart-zoomable"),
  options
);
chart.render();

//
// همگام‌سازی نمودارها
//
var colors = ["#1c84ee"];
var optionsline2 = {
  chart: {
    toolbar: {
      show: false,
    },
    type: "line",
    height: 160,
    id: "fb",
    group: "اجتماعی",
  },
  colors: colors,
  stroke: {
    width: [3],
    curve: "straight",
  },
  toolbar: {
    tools: {
      selection: false,
    },
  },
  fill: {
    opacity: 1,
  },
  tooltip: {
    followCursor: false,
    x: {
      show: false,
    },
    marker: {
      show: false,
    },
    y: {
      title: {
        formatter: function () {
          return "";
        },
      },
    },
  },
  series: [
    {
      name: 'داده',
      data: generateDayWiseTimeSeries(new Date("11 Feb 2017").getTime(), 20, {
        min: 10,
        max: 30,
      }),
    },
  ],
  xaxis: {
    type: "category",
    labels: {
      formatter: function() {
        return "1403"
      }
    }
  },
  grid: {
    row: {
      colors: ["transparent", "transparent"], // می‌تواند آرایه‌ای باشد که در ستون‌ها تکرار می‌شود
      opacity: 0.2,
    },
    borderColor: "#f1f3fa",
  },
};
var chartline2 = new ApexCharts(
  document.querySelector("#line-chart-syncing"),
  optionsline2
);
chartline2.render();

//
// همگام‌سازی Chart-2
//

var colors = ["#4ecac2"];
var options = {
  chart: {
    toolbar: {
      show: false,
    },
    height: 200,
    type: "line",
    id: "yt",
    group: "اجتماعی",
  },
  colors: colors,
  dataLabels: {
    enabled: false,
  },
  toolbar: {
    tools: {
      selection: false,
    },
  },
  tooltip: {
    followCursor: false,
    x: {
      show: false,
    },
    marker: {
      show: false,
    },
    y: {
      title: {
        formatter: function () {
          return "";
        },
      },
    },
  },
  stroke: {
    width: [3],
    curve: "smooth",
  },

  series: [
    {
      data: generateDayWiseTimeSeries(new Date("11 Feb 2017").getTime(), 20, {
        min: 10,
        max: 60,
      }),
    },
  ],
  fill: {
    gradient: {
      enabled: true,
      opacityFrom: 0.6,
      opacityTo: 0.8,
    },
  },
  legend: {
    position: "top",
    horizontalAlign: "left",
  },
  xaxis: {
    type: "category",
    labels: {
      formatter: function() {
        return "1403"
      }
    }
  },
  grid: {
    row: {
      colors: ["transparent", "transparent"], // می‌تواند آرایه‌ای باشد که در ستون‌ها تکرار می‌شود
      opacity: 0.2,
    },
    borderColor: "#f1f3fa",
  },
};
var chart = new ApexCharts(
  document.querySelector("#line-chart-syncing2"),
  options
);
chart.render();

/*
  // این تابع خروجی را در این فرمت تولید می‌کند
  // data = [
      [timestamp, 23],
      [timestamp, 33],
      [timestamp, 12]
      ...
  ]
*/
function generateDayWiseTimeSeries(baseval, count, yrange) {
  var i = 0;
  var series = [];
  while (i < count) {
    var x = baseval;
    var y =
      Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;

    series.push([x, y]);
    baseval += 86400000;
    i++;
  }
  return series;
}

//
// داده‌های گم‌شده
//
var colors = ["#1c84ee", "#ef5f5f", "#4ecac2"];
var options = {
  chart: {
    height: 380,
    type: "line",
    toolbar: {
      show: false,
    },
    zoom: {
      enabled: false,
    },
    animations: {
      enabled: false,
    },
  },
  stroke: {
    width: [5, 5, 4],
    curve: "straight",
  },

  series: [
    {
      name: "پیتر",
      data: [5, 5, 10, 8, 7, 5, 4, null, null, null, 10, 10, 7, 8, 6, 9],
    },
    {
      name: "جانی",
      data: [
        10,
        15,
        null,
        12,
        null,
        10,
        12,
        15,
        null,
        null,
        12,
        null,
        14,
        null,
        null,
        null,
      ],
    },
    {
      name: "دیوید",
      data: [
        null,
        null,
        null,
        null,
        3,
        4,
        1,
        3,
        4,
        6,
        7,
        9,
        5,
        null,
        null,
        null,
      ],
    },
  ],
  colors: colors,
  labels: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16],
  grid: {
    row: {
      colors: ["transparent", "transparent"], // می‌تواند آرایه‌ای باشد که در ستون‌ها تکرار می‌شود
      opacity: 0.2,
    },
    borderColor: "#f1f3fa",
    padding: {
      bottom: 5,
    },
  },
  legend: {
    offsetY: 7,
  },
};

var chart = new ApexCharts(
  document.querySelector("#line-chart-missing"),
  options
);

chart.render();

//
// نمودار خطی خط‌چین
//
var colors = ["#1c84ee", "#ef5f5f", "#4ecac2"];
var options = {
  chart: {
    height: 380,
    type: "line",
    toolbar: {
      show: false,
    },
    zoom: {
      enabled: false,
    },
  },
  dataLabels: {
    enabled: false,
  },
  stroke: {
    width: [3, 5, 3],
    curve: "straight",
    dashArray: [0, 8, 5],
  },
  series: [
    {
      name: "مدت زمان جلسه",
      data: [45, 52, 38, 24, 33, 26, 21, 20, 6, 8, 15, 10],
    },
    {
      name: "بازدیدهای صفحه",
      data: [35, 41, 62, 42, 13, 18, 29, 37, 36, 51, 32, 35],
    },
    {
      name: "کل بازدیدها",
      data: [87, 57, 74, 99, 75, 38, 62, 47, 82, 56, 45, 47],
    },
  ],
  markers: {
    size: 0,
    style: "hollow", // کامل، توخالی، معکوس
  },
  xaxis: {
    categories: [
      "01 مهر",
      "02 مهر",
      "03 مهر",
      "04 مهر",
      "05 مهر",
      "06 مهر",
      "07 مهر",
      "08 مهر",
      "09 مهر",
      "10 مهر",
      "11 مهر",
      "12 مهر",
    ],
  },
  colors: colors,
  tooltip: {
    y: {
      title: {
        formatter: function (val) {
          if (val === "مدت زمان جلسه") return val + " (دقیقه)";
          else if (val === "بازدیدهای صفحه") return val + " در هر جلسه";
          return val;
        },
      },
    },
  },
  grid: {
    borderColor: "#f1f3fa",
  },
  legend: {
    offsetY: 7,
  },
};

var chart = new ApexCharts(
  document.querySelector("#line-chart-dashed"),
  options
);

chart.render();

//
// نمودارهای خطی پله‌ای
//

var ts2 = 1484418600000;
var data = [];
var spikes = [5, -5, 3, -3, 8, -8];
for (var i = 0; i < 30; i++) {
  ts2 = ts2 + 86400000;
  var innerArr = [ts2, dataSeries[1][i].value];
  data.push(innerArr);
}
var colors = ["#ff6c2f"];
var options = {
  chart: {
    type: "line",
    height: 344,
    toolbar: {
      show: false,
    },
  },
  stroke: {
    curve: "stepline",
  },
  dataLabels: {
    enabled: false,
  },
  series: [
    {
      name: 'داده',
      data: [34, 44, 54, 21, 12, 43, 33, 23, 66, 66, 58],
    },
  ],
  colors: colors,
  title: {
    text: "نمودار پله‌ای",
    align: "left",
  },
  markers: {
    hover: {
      sizeOffset: 4,
    },
  },
};
var chart = new ApexCharts(
  document.querySelector("#line-chart-stepline"),
  options
);
chart.render();

//
// نمودار زمان واقعی
//

("use strict");

var lastDate = 0;
var data = [];
function getDayWiseTimeSeries(baseval, count, yrange) {
  var i = 0;
  while (i < count) {
    var x = baseval;
    var y =
      Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;

    data.push({
      x: x,
      y: y,
    });
    lastDate = baseval;
    baseval += 86400000;
    i++;
  }
}

getDayWiseTimeSeries(new Date("11 Feb 2017 GMT").getTime(), 10, {
  min: 10,
  max: 90,
});

function getNewSeries(baseval, yrange) {
  var newDate = baseval + 86400000;
  lastDate = newDate;
  data.push({
    x: newDate,
    y: Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min,
  });
}

function resetData() {
  data = data.slice(data.length - 10, data.length);
}

var colors = ["#4ecac2"];
var options = {
  chart: {
    height: 350,
    type: "line",
    animations: {
      enabled: true,
      easing: "linear",
      dynamicAnimation: {
        speed: 2000,
      },
    },
    toolbar: {
      show: false,
    },
    zoom: {
      enabled: false,
    },
  },
  dataLabels: {
    enabled: false,
  },
  stroke: {
    curve: "smooth",
    width: [3],
  },
  colors: colors,
  series: [
    {
      data: data,
    },
  ],
  markers: {
    size: 0,
  },
  tooltip: {
    x: {
      formatter: function (val) {
        return moment.unix(val).format("1403-MM-DD");
      },
    },
  },
  xaxis: {
    type: "datetime",
    range: 777600000,
    labels: {
      formatter: function (val) {
        return moment.unix(val).format("1403-MM-DD");
      },
    },
    tooltip: {
      enabled: true,
      formatter: function (val) {
        return moment.unix(val).format("1403-MM-DD");
      },
    },
  },
  yaxis: {
    max: 100,
  },
  legend: {
    show: false,
  },
  grid: {
    borderColor: "#f1f3fa",
  },
};
var chart = new ApexCharts(
  document.querySelector("#line-chart-realtime"),
  options
);
chart.render();

var dataPointsLength = 10;

window.setInterval(function () {
  getNewSeries(lastDate, {
    min: 10,
    max: 90,
  });

  chart.updateSeries([
    {
      name: "داده",
      data: data,
    },
  ]);
}, 2000);

/**
 * تم: Larkon - داشبورد مدیریت ریسپانسیو Bootstrap 5
 * نویسنده: Techzaa
 * ماژول/برنامه: نمودارهای Treemap Apex
 */
// TREEMAP پایه
var colors = ["#1c84ee"];
var options = {
  series: [
    {
      data: [
        {
          x: "دهلی نو",
          y: 218,
        },
        {
          x: "کلکته",
          y: 149,
        },
        {
          x: "مومبای",
          y: 184,
        },
        {
          x: "احمدآباد",
          y: 55,
        },
        {
          x: "بنگالورو",
          y: 84,
        },
        {
          x: "پونه",
          y: 31,
        },
        {
          x: "چنای",
          y: 70,
        },
        {
          x: "جیپور",
          y: 30,
        },
        {
          x: "سورت",
          y: 44,
        },
        {
          x: "حیدرآباد",
          y: 68,
        },
        {
          x: "لکنو",
          y: 28,
        },
        {
          x: "ایندور",
          y: 19,
        },
        {
          x: "کانپور",
          y: 29,
        },
      ],
    },
  ],
  colors: colors,
  legend: {
    show: false,
  },
  chart: {
    toolbar: {
      show: false,
    },
    height: 350,
    type: "treemap",
  },
  title: {
    text: "Treemap پایه",
    align: "center",
  },
};
var chart = new ApexCharts(document.querySelector("#basic-treemap"), options);
chart.render();

// TREEMAP با چندین سری
var colors = ["#f9b931", "#22c55e"];
var options = {
  series: [
    {
      name: "رایانه‌های دسکتاپ",
      data: [
        {
          x: "ABC",
          y: 10,
        },
        {
          x: "DEF",
          y: 60,
        },
        {
          x: "XYZ",
          y: 41,
        },
      ],
    },
    {
      name: "موبایل",
      data: [
        {
          x: "ABCD",
          y: 10,
        },
        {
          x: "DEFG",
          y: 20,
        },
        {
          x: "WXYZ",
          y: 51,
        },
        {
          x: "PQR",
          y: 30,
        },
        {
          x: "MNO",
          y: 20,
        },
        {
          x: "CDE",
          y: 30,
        },
      ],
    },
  ],
  legend: {
    show: false,
  },
  chart: {
    toolbar: {
      show: false,
    },
    height: 350,
    type: "treemap",
  },
  colors: colors,
  title: {
    text: "Treemap چند بعدی",
    align: "center",
  },
};
var chart = new ApexCharts(
  document.querySelector("#multiple-treemap"),
  options
);
chart.render();

// TREEMAP توزیع شده
var colors = ["#1c84ee", "#ff6c2f", "#f9b931"];
var options = {
  series: [
    {
      data: [
        {
          x: "دهلی نو",
          y: 218,
        },
        {
          x: "کلکته",
          y: 149,
        },
        {
          x: "مومبای",
          y: 184,
        },
        {
          x: "احمدآباد",
          y: 55,
        },
        {
          x: "بنگالورو",
          y: 84,
        },
        {
          x: "پونه",
          y: 31,
        },
        {
          x: "چنای",
          y: 70,
        },
        {
          x: "جیپور",
          y: 30,
        },
        {
          x: "سورت",
          y: 44,
        },
        {
          x: "حیدرآباد",
          y: 68,
        },
        {
          x: "لکنو",
          y: 28,
        },
        {
          x: "ایندور",
          y: 19,
        },
        {
          x: "کانپور",
          y: 29,
        },
      ],
    },
  ],
  legend: {
    show: false,
  },
  chart: {
    toolbar: {
      show: false,
    },
    height: 350,
    type: "treemap",
  },
  title: {
    text: "Treemap توزیع شده (رنگ متفاوت برای هر سلول)",
    align: "center",
  },
  colors: colors,
  plotOptions: {
    treemap: {
      distributed: true,
      enableShades: false,
    },
  },
};
var chart = new ApexCharts(
  document.querySelector("#distributed-treemap"),
  options
);
chart.render();

// TREEMAP با محدوده رنگ
var colors = ["#1c84ee", "#4ecac2"];
var options = {
  series: [
    {
      data: [
        {
          x: "INTC",
          y: 1.2,
        },
        {
          x: "GS",
          y: 0.4,
        },
        {
          x: "CVX",
          y: -1.4,
        },
        {
          x: "GE",
          y: 2.7,
        },
        {
          x: "CAT",
          y: -0.3,
        },
        {
          x: "RTX",
          y: 5.1,
        },
        {
          x: "CSCO",
          y: -2.3,
        },
        {
          x: "JNJ",
          y: 2.1,
        },
        {
          x: "PG",
          y: 0.3,
        },
        {
          x: "TRV",
          y: 0.12,
        },
        {
          x: "MMM",
          y: -2.31,
        },
        {
          x: "NKE",
          y: 3.98,
        },
        {
          x: "IYT",
          y: 1.67,
        },
      ],
    },
  ],
  legend: {
    show: false,
  },
  chart: {
    toolbar: {
      show: false,
    },
    height: 350,
    type: "treemap",
  },
  title: {
    text: "Treemap با مقیاس رنگ",
    align: "center",
  },
  dataLabels: {
    enabled: true,
    style: {
      fontSize: "12px",
    },
    formatter: function (text, op) {
      return [text, op.value];
    },
    offsetY: -4,
  },
  plotOptions: {
    treemap: {
      enableShades: true,
      shadeIntensity: 0.5,
      reverseNegativeShade: true,
      colorScale: {
        ranges: [
          {
            from: -6,
            to: 0,
            color: colors[0],
          },
          {
            from: 0.001,
            to: 6,
            color: colors[1],
          },
        ],
      },
    },
  },
};
var chart = new ApexCharts(
  document.querySelector("#color-range-treemap"),
  options
);
chart.render();

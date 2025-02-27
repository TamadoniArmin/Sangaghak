/**
 * تم: Larkon - داشبورد مدیریت پاسخگو Bootstrap 5
 * نویسنده: Techzaa
 * ماژول/برنامه: نمودارهای باکس‌پلات Apex
 */

//
// باکس‌پلات پایه
//

var colors = ["#1c84ee", "#22c55e"];
var options = {
    series: [{
        type: 'boxPlot',
        data: [{
            x: 'مهر 1403',
            y: [54, 66, 69, 75, 88]
        },
        {
            x: 'مهر 1403',
            y: [43, 65, 69, 76, 81]
        },
        {
            x: 'مهر 1403',
            y: [31, 39, 45, 51, 59]
        },
        {
            x: 'مهر 1403',
            y: [39, 46, 55, 65, 71]
        },
        {
            x: 'مهر 1403',
            y: [29, 31, 35, 39, 44]
        },
        {
            x: 'مهر 1403',
            y: [41, 49, 58, 61, 67]
        },
        {
            x: 'مهر 1403',
            y: [54, 59, 66, 71, 88]
        }
        ]
    }],
    chart: {
        type: 'boxPlot',
        height: 350,
        toolbar: {
            show: false
        }
    },
    plotOptions: {
        boxPlot: {
            colors: {
                upper: colors[0],
                lower: colors[1]
            }
        }
    },
    stroke: {
        colors: ['#a1a9b1']
    }
};
var chart = new ApexCharts(document.querySelector("#basic-boxplot"), options);
chart.render();

//
// باکس‌پلات پراکنده
//

var colors = ["#1c84ee", "#22c55e"];
var options = {
    series: [{
        name: 'باکس',
        type: 'boxPlot',
        data: [{
            x: '1395-10-11', // معادل شمسی 2017-01-01
            y: [54, 66, 69, 75, 88]
        },
        {
            x: '1396-10-11', // معادل شمسی 2018-01-01
            y: [43, 65, 69, 76, 81]
        },
        {
            x: '1397-10-11', // معادل شمسی 2019-01-01
            y: [31, 39, 45, 51, 59]
        },
        {
            x: '1398-10-11', // معادل شمسی 2020-01-01
            y: [39, 46, 55, 65, 71]
        },
        {
            x: '1399-10-11', // معادل شمسی 2021-01-01
            y: [29, 31, 35, 39, 44]
        }
        ]
    },
    {
        name: 'نقاط پرت',
        type: 'scatter',
        data: [{
            x: '1395-10-11', // معادل شمسی 2017-01-01
            y: 32
        },
        {
            x: '1396-10-11', // معادل شمسی 2018-01-01
            y: 25
        },
        {
            x: '1397-10-11', // معادل شمسی 2019-01-01
            y: 64
        },
        {
            x: '1398-10-11', // معادل شمسی 2020-01-01
            y: 27
        },
        {
            x: '1398-10-11', // معادل شمسی 2020-01-01
            y: 78
        },
        {
            x: '1399-10-11', // معادل شمسی 2021-01-01
            y: 15
        }
        ]
    }
    ],
    chart: {
        type: 'boxPlot',
        height: 350,
        toolbar: {
            show: false
        }
    },
    colors: colors,
    stroke: {
        colors: ['#a1a9b1']
    },
    legend: {
        offsetY: 10,
    },
    xaxis: {
        type: 'category', // نوع محور را به 'category' تغییر دهید
        tooltip: {
            formatter: function (val) {
                // تاریخ شمسی در تولتیپ
                return val;
            }
        }
    },
    grid: {
        padding: {
            bottom: 5
        }
    },
    tooltip: {
        shared: false,
        intersect: true
    },
    plotOptions: {
        boxPlot: {
            colors: {
                upper: colors[0],
                lower: colors[1]
            }
        }
    },
};


var chart = new ApexCharts(document.querySelector("#scatter-boxplot"), options);
chart.render();

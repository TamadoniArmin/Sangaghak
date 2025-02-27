/**
 * تم: Larkon - داشبورد مدیریتی Responsive Bootstrap 5
 * نویسنده: Techzaa
 * ماژول/برنامه: نمودارهای منطقه‌ای Apex
 */

//
// نقشه حرارتی پایه - سری تک
//

/*
// این تابع خروجی به این فرمت تولید می‌کند
// data = [
    [timestamp, 23],
    [timestamp, 33],
    [timestamp, 12]
    ...
]
*/
function generateData(count, yrange) {
    var i = 0;
    var series = [];
    while (i < count) {
        var x = (i + 1).toString();
        var y = Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;

        series.push({
            x: x,
            y: y
        });
        i++;
    }
    return series;
}

var colors = ["#1c84ee"];
var options = {
    chart: {
        toolbar: {
        show: false,
        },
        height: 380,
        type: 'heatmap',
    },
    dataLabels: {
        enabled: false
    },
    colors: colors,
    series: [{
        name: 'معیار 1',
        data: generateData(20, {
            min: 0,
            max: 90
        })
    },
    {
        name: 'معیار 2',
        data: generateData(20, {
            min: 0,
            max: 90
        })
    },
    {
        name: 'معیار 3',
        data: generateData(20, {
            min: 0,
            max: 90
        })
    },
    {
        name: 'معیار 4',
        data: generateData(20, {
            min: 0,
            max: 90
        })
    },
    {
        name: 'معیار 5',
        data: generateData(20, {
            min: 0,
            max: 90
        })
    },
    {
        name: 'معیار 6',
        data: generateData(20, {
            min: 0,
            max: 90
        })
    },
    {
        name: 'معیار 7',
        data: generateData(20, {
            min: 0,
            max: 90
        })
    },
    {
        name: 'معیار 8',
        data: generateData(20, {
            min: 0,
            max: 90
        })
    },
    {
        name: 'معیار 9',
        data: generateData(20, {
            min: 0,
            max: 90
        })
    }
    ],
    xaxis: {
        type: 'category',
    },

}

var chart = new ApexCharts(
    document.querySelector("#basic-heatmap"),
    options
);

chart.render();


//
// نقشه حرارتی - چندین سری
//

/*
// این تابع خروجی به این فرمت تولید می‌کند
// data = [
    [timestamp, 23],
    [timestamp, 33],
    [timestamp, 12]
    ...
]
*/

var colors = ["#1c84ee", "#53389f", "#7f56da", "#ff86c8", "#ef5f5f", "#ff6c2f", "#f9b931", '#22c55e','#4ecac2'];
var options = {
    chart: {
        toolbar: {
        show: false,
        },
        height: 380,
        type: 'heatmap',
    },
    dataLabels: {
        enabled: false
    },
    colors: colors,
    series: [{
            name: 'معیار 1',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 2',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 3',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 4',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 5',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 6',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 7',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 8',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 9',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        }
    ],
    xaxis: {
        type: 'category',
    },
}
var chart = new ApexCharts(
document.querySelector("#multiple-series-heatmap"),
options
);
chart.render();


//
// نقشه حرارتی - محدوده رنگ
//

/*
// این تابع خروجی به این فرمت تولید می‌کند
// data = [
    [timestamp, 23],
    [timestamp, 33],
    [timestamp, 12]
    ...
]
*/

var colors = ["#1c84ee","#ef5f5f","#f9b931","#22c55e"];
var options = {
chart: {
    toolbar: {
        show: false,
        },
    height: 380,
    type: 'heatmap',
},
plotOptions: {
    heatmap: {
        shadeIntensity: 0.5,

        colorScale: {
            ranges: [{
                    from: -30,
                    to: 5,
                    name: 'کم',
                    color: colors[0]
                },
                {
                    from: 6,
                    to: 20,
                    name: 'متوسط',
                    color: colors[1]
                },
                {
                    from: 21,
                    to: 45,
                    name: 'زیاد',
                    color: colors[2]
                },
                {
                    from: 46,
                    to: 55,
                    name: 'بسیار زیاد',
                    color: colors[3]
                }
            ]
        }
    }
},
dataLabels: {
    enabled: false
},
series: [{
        name: 'ژانویه',
        data: generateData(20, {
            min: -30,
            max: 55
        })
    },
    {
        name: 'فوریه',
        data: generateData(20, {
            min: -30,
            max: 55
        })
    },
    {
        name: 'مارس',
        data: generateData(20, {
            min: -30,
            max: 55
        })
    },
    {
        name: 'آوریل',
        data: generateData(20, {
            min: -30,
            max: 55
        })
    },
    {
        name: 'مه',
        data: generateData(20, {
            min: -30,
            max: 55
        })
    },
    {
        name: 'ژوئن',
        data: generateData(20, {
            min: -30,
            max: 55
        })
    },
    {
        name: 'ژوئیه',
        data: generateData(20, {
            min: -30,
            max: 55
        })
    },
    {
        name: 'اوت',
        data: generateData(20, {
            min: -30,
            max: 55
        })
    },
    {
        name: 'سپتامبر',
        data: generateData(20, {
            min: -30,
            max: 55
        })
    }
],

}

var chart = new ApexCharts(
document.querySelector("#color-range-heatmap"),
options
);

chart.render();


//
// نقشه حرارتی - محدوده بدون سایه
//

/*
// این تابع خروجی به این فرمت تولید می‌کند
// data = [
    [timestamp, 23],
    [timestamp, 33],
    [timestamp, 12]
    ...
]
*/

var colors = ["#1c84ee","#4ecac2"];
var options = {
    chart: {
        toolbar: {
        show: false,
        },
        height: 380,
        type: 'heatmap',
    },
    stroke: {
        width: 0
    },
    plotOptions: {
        heatmap: {
            radius: 30,
            enableShades: false,
            colorScale: {
                ranges: [{
                        from: 0,
                        to: 50,
                        color: colors[0]
                    },
                    {
                        from: 51,
                        to: 100,
                        color: colors[1]
                    },
                ],
            },

        }
    },
    colors: colors,
    dataLabels: {
        enabled: true,
        style: {
            colors: ['#fff']
        }
    },
    series: [{
            name: 'معیار 1',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 2',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 3',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 4',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 5',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 6',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 7',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 8',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        },
        {
            name: 'معیار 9',
            data: generateData(20, {
                min: 0,
                max: 90
            })
        }
    ],

    xaxis: {
        type: 'category',
    },
    grid: {
        borderColor: '#f1f3fa'
    }
}

var chart = new ApexCharts(
document.querySelector("#rounded-heatmap"),
options
);

chart.render();

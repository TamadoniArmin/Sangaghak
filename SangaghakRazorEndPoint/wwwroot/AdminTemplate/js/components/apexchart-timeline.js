/**
 * تم: Larkon - داشبورد مدیریت ریسپانسیو Bootstrap 5
 * نویسنده: Techzaa
 * ماژول/اپلیکیشن: نمودارهای زمانبندی Apex
 */
// زمانبندی پایه
var colors = ["#4ecac2"];
var options = {
    series: [{
        data: [{
            x: 'کد',
            y: [
                new Date('2019-03-02').getTime(),
                new Date('2019-03-04').getTime()
            ]
        },
        {
            x: 'آزمایش',
            y: [
                new Date('2019-03-04').getTime(),
                new Date('2019-03-08').getTime()
            ]
        },
        {
            x: 'اعتبارسنجی',
            y: [
                new Date('2019-03-08').getTime(),
                new Date('2019-03-12').getTime()
            ]
        },
        {
            x: 'استقرار',
            y: [
                new Date('2019-03-12').getTime(),
                new Date('2019-03-18').getTime()
            ]
        }
        ]
    }],
    chart: {
        height: 350,
        type: 'rangeBar',
        toolbar: {
            show: false
        }
    },
    colors: colors,
    plotOptions: {
        bar: {
            horizontal: true
        }
    },
    xaxis: {
        type: "category",
        labels: {
          formatter: function() {
            return "1403"
          }
        }
      },
};
var chart = new ApexCharts(document.querySelector("#basic-timeline"), options);
chart.render();


// زمانبندی توزیع شده
var colors = ["#1c84ee", "#7f56da", "#ff86c8", "#f9b931", "#4ecac2"];
var options = {
    series: [{
        data: [{
            x: 'تحلیل',
            y: [
                new Date('2019-02-27').getTime(),
                new Date('2019-03-04').getTime()
            ],
            fillColor: colors[0]
        },
        {
            x: 'طراحی',
            y: [
                new Date('2019-03-04').getTime(),
                new Date('2019-03-08').getTime()
            ],
            fillColor: colors[1]
        },
        {
            x: 'کدنویسی',
            y: [
                new Date('2019-03-07').getTime(),
                new Date('2019-03-10').getTime()
            ],
            fillColor: colors[2]
        },
        {
            x: 'آزمایش',
            y: [
                new Date('2019-03-08').getTime(),
                new Date('2019-03-12').getTime()
            ],
            fillColor: colors[3]
        },
        {
            x: 'استقرار',
            y: [
                new Date('2019-03-12').getTime(),
                new Date('2019-03-17').getTime()
            ],
            fillColor: colors[4]
        }
        ]
    }],
    chart: {
        height: 350,
        type: 'rangeBar',
        toolbar: {
            show: false
        }
    },
    plotOptions: {
        bar: {
            horizontal: true,
            distributed: true,
            dataLabels: {
                hideOverflowingLabels: false
            }
        }
    },
    dataLabels: {
        enabled: true,
        formatter: function (val, opts) {
            var label = opts.w.globals.labels[opts.dataPointIndex]
            var a = moment(val[0])
            var b = moment(val[1])
            var diff = b.diff(a, 'days')
            return label + ': ' + diff + (diff > 1 ? ' روز' : ' روز')
        },
        style: {
            colors: ['#f3f4f5', '#fff']
        }
    },
    xaxis: {
        type: "category",
        labels: {
          formatter: function() {
            return "1403"
          }
        }
      },
    yaxis: {
        show: false
    },
    grid: {
        row: {
            colors: ['#f3f4f5', '#fff'],
            opacity: 1
        },
        padding: {
            top: -15,
            right: 10,
            bottom: -15,
            left: -10,
        }
    }
};
var chart = new ApexCharts(document.querySelector("#distributed-timeline"), options);
chart.render();


// زمانبندی چندسری
var colors = ["#ff6c2f", "#f9b931"];
var options = {
    series: [{
        name: 'باب',
        data: [{
            x: 'طراحی',
            y: [
                new Date('2019-03-05').getTime(),
                new Date('2019-03-08').getTime()
            ]
        },
        {
            x: 'کد',
            y: [
                new Date('2019-03-08').getTime(),
                new Date('2019-03-11').getTime()
            ]
        },
        {
            x: 'آزمایش',
            y: [
                new Date('2019-03-11').getTime(),
                new Date('2019-03-16').getTime()
            ]
        }
        ]
    },
    {
        name: 'جو',
        data: [{
            x: 'طراحی',
            y: [
                new Date('2019-03-02').getTime(),
                new Date('2019-03-05').getTime()
            ]
        },
        {
            x: 'کد',
            y: [
                new Date('2019-03-06').getTime(),
                new Date('2019-03-09').getTime()
            ]
        },
        {
            x: 'آزمایش',
            y: [
                new Date('2019-03-10').getTime(),
                new Date('2019-03-19').getTime()
            ]
        }
        ]
    }
    ],
    chart: {
        height: 350,
        type: 'rangeBar',
        toolbar: {
            show: false
        }
    },
    plotOptions: {
        bar: {
            horizontal: true
        }
    },
    dataLabels: {
        enabled: true,
        formatter: function (val) {
            var a = moment(val[0])
            var b = moment(val[1])
            var diff = b.diff(a, 'days')
            return diff + (diff > 1 ? ' روز' : ' روز')
        }
    },
    fill: {
        type: 'gradient',
        gradient: {
            shade: 'light',
            type: 'vertical',
            shadeIntensity: 0.25,
            gradientToColors: undefined,
            inverseColors: true,
            opacityFrom: 1,
            opacityTo: 1,
            stops: [50, 0, 100, 100]
        }
    },
    colors: colors,
    xaxis: {
        type: "category",
        labels: {
          formatter: function() {
            return "1403"
          }
        }
      },
    legend: {
        position: 'top'
    }
};
var chart = new ApexCharts(document.querySelector("#multi-series-timeline"), options);
chart.render();


// زمانبندی پیشرفته
var colors = ["#ef5f5f", "#f9b931", "#4ecac2"];
var options = {
    series: [{
        name: 'باب',
        data: [{
            x: 'طراحی',
            y: [
                new Date('2019-03-05').getTime(),
                new Date('2019-03-08').getTime()
            ]
        },
        {
            x: 'کد',
            y: [
                new Date('2019-03-02').getTime(),
                new Date('2019-03-05').getTime()
            ]
        },
        {
            x: 'کد',
            y: [
                new Date('2019-03-05').getTime(),
                new Date('2019-03-07').getTime()
            ]
        },
        {
            x: 'آزمایش',
            y: [
                new Date('2019-03-03').getTime(),
                new Date('2019-03-09').getTime()
            ]
        },
        {
            x: 'آزمایش',
            y: [
                new Date('2019-03-08').getTime(),
                new Date('2019-03-11').getTime()
            ]
        },
        {
            x: 'اعتبارسنجی',
            y: [
                new Date('2019-03-11').getTime(),
                new Date('2019-03-16').getTime()
            ]
        },
        {
            x: 'طراحی',
            y: [
                new Date('2019-03-01').getTime(),
                new Date('2019-03-03').getTime()
            ],
        }
        ]
    },
    {
        name: 'جو',
        data: [{
            x: 'طراحی',
            y: [
                new Date('2019-03-02').getTime(),
                new Date('2019-03-05').getTime()
            ]
        },
        {
            x: 'آزمایش',
            y: [
                new Date('2019-03-06').getTime(),
                new Date('2019-03-16').getTime()
            ],
            goals: [{
                name: 'استراحت',
                value: new Date('2019-03-10').getTime(),
                strokeColor: '#CD2F2A'
            }]
        },
        {
            x: 'کد',
            y: [
                new Date('2019-03-03').getTime(),
                new Date('2019-03-07').getTime()
            ]
        },
        {
            x: 'استقرار',
            y: [
                new Date('2019-03-20').getTime(),
                new Date('2019-03-22').getTime()
            ]
        },
        {
            x: 'طراحی',
            y: [
                new Date('2019-03-10').getTime(),
                new Date('2019-03-16').getTime()
            ]
        }
        ]
    },
    {
        name: 'دن',
        data: [{
            x: 'کد',
            y: [
                new Date('2019-03-10').getTime(),
                new Date('2019-03-17').getTime()
            ]
        },
        {
            x: 'اعتبارسنجی',
            y: [
                new Date('2019-03-05').getTime(),
                new Date('2019-03-09').getTime()
            ],
            goals: [{
                name: 'استراحت',
                value: new Date('2019-03-07').getTime(),
                strokeColor: '#CD2F2A'
            }]
        },
        ]
    }
    ],
    chart: {
        height: 350,
        type: 'rangeBar',
        toolbar: {
            show: false
        }
    },
    plotOptions: {
        bar: {
            horizontal: true,
            barHeight: '80%'
        }
    },
    xaxis: {
        type: "category",
        labels: {
          formatter: function() {
            return "1403"
          }
        }
      },
    stroke: {
        width: 1
    },
    colors: colors,
    fill: {
        type: 'solid',
        opacity: 0.6
    },
    legend: {
        position: 'top',
        horizontalAlign: 'left'
    }
};
var chart = new ApexCharts(document.querySelector("#advanced-timeline"), options);
chart.render();

// چندین سری - گروه بندی ردیف‌ها
var colors = ["#1c84ee", "#7f56da", "#ff86c8", "#f9b931", "#4ecac2"];
var options = {
    series: [
        // جورج واشنگتن
        {
            name: 'جورج واشنگتن',
            data: [{
                x: 'رئیس جمهور',
                y: [
                    new Date(1789, 3, 30).getTime(),
                    new Date(1797, 2, 4).getTime()
                ]
            },]
        },
        // جان آدامز
        {
            name: 'جان آدامز',
            data: [{
                x: 'رئیس جمهور',
                y: [
                    new Date(1797, 2, 4).getTime(),
                    new Date(1801, 2, 4).getTime()
                ]
            },
            {
                x: 'معاون رئیس جمهور',
                y: [
                    new Date(1789, 3, 21).getTime(),
                    new Date(1797, 2, 4).getTime()
                ]
            }
            ]
        },
        // توماس جفرسون
        {
            name: 'توماس جفرسون',
            data: [{
                x: 'رئیس جمهور',
                y: [
                    new Date(1801, 2, 4).getTime(),
                    new Date(1809, 2, 4).getTime()
                ]
            },
            {
                x: 'معاون رئیس جمهور',
                y: [
                    new Date(1797, 2, 4).getTime(),
                    new Date(1801, 2, 4).getTime()
                ]
            },
            {
                x: 'وزیر امور خارجه',
                y: [
                    new Date(1790, 2, 22).getTime(),
                    new Date(1793, 11, 31).getTime()
                ]
            }
            ]
        },
        // آرون بور
        {
            name: 'آرون بور',
            data: [{
                x: 'معاون رئیس جمهور',
                y: [
                    new Date(1801, 2, 4).getTime(),
                    new Date(1805, 2, 4).getTime()
                ]
            }]
        },
        // جورج کلینتون
        {
            name: 'جورج کلینتون',
            data: [{
                x: 'معاون رئیس جمهور',
                y: [
                    new Date(1805, 2, 4).getTime(),
                    new Date(1812, 3, 20).getTime()
                ]
            }]
        },
        // جان جی
        {
            name: 'جان جی',
            data: [{
                x: 'وزیر امور خارجه',
                y: [
                    new Date(1789, 8, 25).getTime(),
                    new Date(1790, 2, 22).getTime()
                ]
            }]
        },
        // ادموند رندولف
        {
            name: 'ادموند رندولف',
            data: [{
                x: 'وزیر امور خارجه',
                y: [
                    new Date(1794, 0, 2).getTime(),
                    new Date(1795, 7, 20).getTime()
                ]
            }]
        },
        // تیموتی پیکرینگ
        {
            name: 'تیموتی پیکرینگ',
            data: [{
                x: 'وزیر امور خارجه',
                y: [
                    new Date(1795, 7, 20).getTime(),
                    new Date(1800, 4, 12).getTime()
                ]
            }]
        },
        // چارلز لی
        {
            name: 'چارلز لی',
            data: [{
                x: 'وزیر امور خارجه',
                y: [
                    new Date(1800, 4, 13).getTime(),
                    new Date(1800, 5, 5).getTime()
                ]
            }]
        },
        // جان مارشال
        {
            name: 'جان مارشال',
            data: [{
                x: 'وزیر امور خارجه',
                y: [
                    new Date(1800, 5, 13).getTime(),
                    new Date(1801, 2, 4).getTime()
                ]
            }]
        },
        // لویی لینکلن
        {
            name: 'لویی لینکلن',
            data: [{
                x: 'وزیر امور خارجه',
                y: [
                    new Date(1801, 2, 5).getTime(),
                    new Date(1801, 4, 1).getTime()
                ]
            }]
        },
        // جیمز مدیسون
        {
            name: 'جیمز مدیسون',
            data: [{
                x: 'وزیر امور خارجه',
                y: [
                    new Date(1801, 4, 2).getTime(),
                    new Date(1809, 2, 3).getTime()
                ]
            }]
        },
    ],
    chart: {
        height: 350,
        type: 'rangeBar',
        toolbar: {
            show: false
        }
    },
    plotOptions: {
        bar: {
            horizontal: true,
            barHeight: '50%',
            rangeBarGroupRows: true
        }
    },
    colors: colors,
    fill: {
        type: 'solid'
    },
    xaxis: {
        type: "category",
        labels: {
          formatter: function() {
            return "1403"
          }
        }
      },
    legend: {
        position: 'right'
    },
};
var chart = new ApexCharts(document.querySelector("#group-rows-timeline"), options);
chart.render();

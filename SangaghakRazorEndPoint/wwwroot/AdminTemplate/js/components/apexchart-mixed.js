/**
 * تم: Larkon - داشبورد مدیریت ریسپانسیو Bootstrap 5
 * نویسنده: Techzaa
 * ماژول/برنامه: نمودارهای ترکیبی Apex
 */

//
// نمودار خطی و ستونی
//
var colors = ["#1c84ee", "#4ecac2"];
var options = {
    chart: {
        height: 380,
        type: 'line',
        toolbar: {
            show: false
        }
    },
    series: [{
        name: 'وبلاگ سایت',
        type: 'column',
        data: [440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160]
    }, {
        name: 'رسانه‌های اجتماعی',
        type: 'line',
        data: [23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16]
    }],
    stroke: {
        width: [0, 4]
    },
    labels: ['01 ژانویه 1403', '02 ژانویه 1403', '03 ژانویه 1403', '04 ژانویه 1403', '05 ژانویه 1403', '06 ژانویه 1403', '07 ژانویه 1403', '08 ژانویه 1403', '09 ژانویه 1403', '10 ژانویه 1403', '11 ژانویه 1403', '12 ژانویه 1403'],
    xaxis: {
        type: "category",
        labels: {
          formatter: function() {
            return "1403"
          }
        }
      },
    colors: colors,
    yaxis: [{
        title: {
            text: 'وبلاگ سایت',
        },

    }, {
        opposite: true,
        title: {
            text: 'رسانه‌های اجتماعی'
        }
    }],
    legend: {
        offsetY: 7,
    },
    grid: {
        borderColor: '#f1f3fa',
        padding: {
            bottom: 5
        }
      }

}
var chart = new ApexCharts(
    document.querySelector("#line-column-mixed"),
    options
);
chart.render();


//
// نمودار چند محور Y
//
var colors = ["#1c84ee", "#4ecac2", "#f9b931"];
var options = {
    chart: {
        height: 380,
        type: 'line',
        stacked: false,
        toolbar: {
            show: false
        }
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        width: [0, 0, 3]
    },
    series: [{
        name: 'درآمد',
        type: 'column',
        data: [1.4, 2, 2.5, 1.5, 2.5, 2.8, 3.8, 4.6]
    }, {
        name: 'جریان نقدی',
        type: 'column',
        data: [1.1, 3, 3.1, 4, 4.1, 4.9, 6.5, 8.5]
    }, {
        name: 'درآمد کل',
        type: 'line',
        data: [20, 29, 37, 36, 44, 45, 50, 58]
    }],
    colors: colors,
    xaxis: {
        type: "category",
        labels: {
          formatter: function() {
            return "1403"
          }
        }
      },
    yaxis: [
        {
            axisTicks: {
                show: true,
            },
            axisBorder: {
                show: true,
                color: colors[0]
            },
            labels: {
                style: {
                    color: colors[0]
                }
            },
            title: {
                text: "درآمد (هزار کرو) "
            },
        },

        {
            axisTicks: {
                show: true,
            },
            axisBorder: {
                show: true,
                color: colors[1]
            },
            labels: {
                style: {
                    color: colors[1]
                },
                offsetX: 10
            },
            title: {
                text: "جریان نقدی (هزار کرو)",
            },
        },
        {
            opposite: true,
            axisTicks: {
                show: true,
            },
            axisBorder: {
                show: true,
                color: colors[2]
            },
            labels: {
                style: {
                    color: colors[2]
                }
            },
            title: {
                text: "درآمد کل (هزار کرو)"
            }
        },

    ],
    tooltip: {
        followCursor: true,
        y: {
            formatter: function (y) {
                if (typeof y !== "undefined") {
                    return y + " هزار کرو"
                }
                return y;
            }
        }
    },
    grid: {
        borderColor: '#f1f3fa',
        padding: {
            bottom: 5
        }
    },
    legend: {
        offsetY: 7,
    },
    responsive: [{
        breakpoint: 600,
        options: {
            yaxis: {
                show: false
            },
            legend: {
                show: false
            }
        }
    }]
}
var chart = new ApexCharts(
    document.querySelector("#multiple-yaxis-mixed"),
    options
);
chart.render();


//
// نمودار خطی و ناحیه‌ای
//
var colors = ["#4ecac2", "#1c84ee"];
var options = {
    chart: {
        height: 380,
        type: 'line',
        toolbar: {
            show: false
        }
    },
    stroke: {
        curve: 'smooth',
        width: 2
    },
    series: [{
        name: 'تیم A',
        type: 'area',
        data: [44, 55, 31, 47, 31, 43, 26, 41, 31, 47, 33]
    }, {
        name: 'تیم B',
        type: 'line',
        data: [55, 69, 45, 61, 43, 54, 37, 52, 44, 61, 43]
    }],
    fill: {
        type: 'solid',
        opacity: [0.35, 1],
    },
    labels: ['01 تیر', '02 تیر', '03 تیر', '04 تیر', '05 تیر', '06 تیر', '07 تیر', '08 تیر', '09 تیر', '10 تیر', '11 تیر'],
    markers: {
        size: 0
    },
    legend: {
        offsetY: 7,
    },
    colors: colors,
    yaxis: [
        {
            title: {
                text: 'سری A',
            },
        },
        {
            opposite: true,
            title: {
                text: 'سری B',
            },
        },
    ],
    tooltip: {
        shared: true,
        intersect: false,
        y: {
            formatter: function (y) {
                if (typeof y !== "undefined") {
                    return y.toFixed(0) + " امتیاز";
                }
                return y;

            }
        }
    },
    grid: {
        borderColor: '#f1f3fa',
        padding: {
            bottom: 5
        }
    },
    responsive: [{
        breakpoint: 600,
        options: {
            yaxis: {
                show: false
            },
            legend: {
                show: false
            }
        }
    }]
}
var chart = new ApexCharts(
    document.querySelector("#line-area-mixed"),
    options
);
chart.render();


//
// نمودار خطی، ستونی و ناحیه‌ای
//
var colors = ["#4ecac2", "#f9b931", "#ff6c2f"];
var options = {
    chart: {
        height: 380,
        type: 'line',
        stacked: false,
        toolbar: {
            show: false
        }
    },
    stroke: {
        width: [0, 2, 4],
        curve: 'smooth'
    },
    plotOptions: {
        bar: {
            columnWidth: '50%'
        }
    },
    colors: colors,
    series: [{
        name: 'تیم A',
        type: 'column',
        data: [23, 11, 22, 27, 13, 22, 37, 21, 44, 22, 30]
    }, {
        name: 'تیم B',
        type: 'area',
        data: [44, 55, 41, 67, 22, 43, 21, 41, 56, 27, 43]
    }, {
        name: 'تیم C',
        type: 'line',
        data: [30, 25, 36, 30, 45, 35, 64, 52, 59, 36, 39]
    }],
    fill: {
        opacity: [0.85, 0.25, 1],
        gradient: {
            inverseColors: false,
            shade: 'light',
            type: "vertical",
            opacityFrom: 0.85,
            opacityTo: 0.55,
            stops: [0, 100, 100, 100]
        }
    },
    labels: ['01/01/1403', '02/01/1403', '03/01/1403', '04/01/1403', '05/01/1403', '06/01/1403', '07/01/1403', '08/01/1403', '09/01/1403', '10/01/1403', '11/01/1403'],
    markers: {
        size: 0
    },
    legend: {
        offsetY: 7,
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
        title: {
            text: 'امتیاز',
        },
    },
    tooltip: {
        shared: true,
        intersect: false,
        y: {
            formatter: function (y) {
                if (typeof y !== "undefined") {
                    return y.toFixed(0) + " امتیاز";
                }
                return y;

            }
        }
    },
    grid: {
        borderColor: '#f1f3fa',
        padding: {
            bottom: 5
        }
    }
}
var chart = new ApexCharts(
    document.querySelector("#all-mixed"),
    options
);
chart.render();

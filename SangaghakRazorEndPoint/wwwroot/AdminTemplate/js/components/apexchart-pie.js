/**
 * تم: Larkon - داشبورد مدیریت ریسپانسیو بوت‌استرپ 5
 * نویسنده: Techzaa
 * ماژول/اپلیکیشن: نمودارهای پای آپکس
 */
//
// نمودار پای ساده
//
var colors = ["#1c84ee", "#7f56da","#ff6c2f", "#f9b931","#4ecac2"];
var options = {
    chart: {
        height: 320,
        type: 'pie',
    },
    series: [44, 55, 41, 17, 15],
    labels: ["سری 1", "سری 2", "سری 3", "سری 4", "سری 5"],
    colors: colors,
    legend: {
        show: true,
        position: 'bottom',
        horizontalAlign: 'center',
        verticalAlign: 'middle',
        floating: false,
        fontSize: '14px',
        offsetX: 0,
        offsetY: 7
    },
    responsive: [{
        breakpoint: 600,
        options: {
            chart: {
                height: 240
            },
            legend: {
                show: false
            },
        }
    }]
}
var chart = new ApexCharts(
    document.querySelector("#simple-pie"),
    options
);
chart.render();

//
// نمودار دونات ساده
//
var colors = ["#7f56da", "#1c84ee","#ff6c2f", "#4ecac2","#f9b931"];
var options = {
    chart: {
        height: 320,
        type: 'donut',
    },
    series: [44, 55, 41, 17, 15],
    legend: {
        show: true,
        position: 'bottom',
        horizontalAlign: 'center',
        verticalAlign: 'middle',
        floating: false,
        fontSize: '14px',
        offsetX: 0,
        offsetY: 7
    },
    labels: ["سری 1", "سری 2", "سری 3", "سری 4", "سری 5"],
    colors: colors,
    responsive: [{
        breakpoint: 600,
        options: {
            chart: {
                height: 240
            },
            legend: {
                show: false
            },
        }
    }]
}
var chart = new ApexCharts(
    document.querySelector("#simple-donut"),
    options
);
chart.render();

//
// نمودار پای تک رنگ
//
var options = {
    chart: {
        height: 320,
        type: 'pie',
    },
    series: [25, 15, 44, 55, 41, 17],
    labels: ["دوشنبه", "سه‌شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه"],
    legend: {
        show: true,
        position: 'bottom',
        horizontalAlign: 'center',
        verticalAlign: 'middle',
        floating: false,
        fontSize: '14px',
        offsetX: 0,
        offsetY: 7
    },
    theme: {
        monochrome: {
            enabled: true
        }
    },
    responsive: [{
        breakpoint: 600,
        options: {
            chart: {
                height: 240
            },
            legend: {
                show: false
            },
        }
    }]
}
var chart = new ApexCharts(
    document.querySelector("#monochrome-pie"),
    options
);
chart.render();

//
// نمودار دونات گرادیان
//
var colors = ["#7f56da", "#1c84ee","#ff6c2f", "#4ecac2","#f9b931"];
var options = {
    chart: {
        height: 320,
        type: 'donut',
    },
    series: [44, 55, 41, 17, 15],
    legend: {
        show: true,
        position: 'bottom',
        horizontalAlign: 'center',
        verticalAlign: 'middle',
        floating: false,
        fontSize: '14px',
        offsetX: 0,
        offsetY: 7
    },
    labels: ["سری 1", "سری 2", "سری 3", "سری 4", "سری 5"],
    colors: colors,
    responsive: [{
        breakpoint: 600,
        options: {
            chart: {
                height: 240
            },
            legend: {
                show: false
            },
        }
    }],
    fill: {
        type: 'gradient'
    }
}
var chart = new ApexCharts(
    document.querySelector("#gradient-donut"),
    options
);
chart.render();

//
// نمودار دونات با الگو
//
var colors = ["#7f56da", "#1c84ee","#ff6c2f", "#4ecac2","#f9b931"];
var options = {
    chart: {
        height: 320,
        type: 'donut',
        dropShadow: {
          enabled: true,
          color: '#111',
          top: -1,
          left: 3,
          blur: 3,
          opacity: 0.2
        }
    },
    stroke: {
        show: true,
        width: 2,
    },
    series: [44, 55, 41, 17, 15],
    colors: colors,
    labels: ["کمدی", "اکشن", "علمی تخیلی", "درام", "ترسناک"],
    dataLabels: {
        dropShadow: {
            blur: 3,
            opacity: 0.8
        }
    },
    fill: {
    type: 'pattern',
      opacity: 1,
      pattern: {
        enabled: true,
        style: ['خطوط عمودی', 'مربع', 'خطوط افقی', 'دایره','خطوط کج'],
      },
    },
    states: {
      hover: {
        enabled: false
      }
    },
    legend: {
        show: true,
        position: 'bottom',
        horizontalAlign: 'center',
        verticalAlign: 'middle',
        floating: false,
        fontSize: '14px',
        offsetX: 0,
        offsetY: 7
    },
    responsive: [{
        breakpoint: 600,
        options: {
            chart: {
                height: 240
            },
            legend: {
                show: false
            },
        }
    }]
}
var chart = new ApexCharts(
    document.querySelector("#patterned-donut"),
    options
);
chart.render();

//
// نمودار پای با پر کردن تصویر
//
var options = {
    chart: {
        height: 320,
        type: 'pie',
    },
    labels: ["سری 1", "سری 2", "سری 3", "سری 4"],
    colors: colors,
    series: [44, 33, 54, 45],
    fill: {
        type: 'image',
        opacity: 0.85,
        image: {
             src: ['/images/small/img-1.jpg', '/images/small/img-2.jpg', '/images/small/img-3.jpg', '/images/small/img-5.jpg'],
            width: 25,
            imagedHeight: 25
        },
    },
    stroke: {
        width: 4
    },
    dataLabels: {
        enabled: false
    },
    legend: {
        show: true,
        position: 'bottom',
        horizontalAlign: 'center',
        verticalAlign: 'middle',
        floating: false,
        fontSize: '14px',
        offsetX: 0,
        offsetY: 7
    },
    responsive: [{
        breakpoint: 600,
        options: {
            chart: {
                height: 240
            },
            legend: {
                show: false
            },
        }
    }]
}
var chart = new ApexCharts(
    document.querySelector("#image-pie"),
    options
);
chart.render();

//
// بروزرسانی دونات
//
var colors = ["#1c84ee", "#53389f", "#7f56da", "#ff86c8", "#ef5f5f", "#ff6c2f", "#f9b931", "#22c55e", "#040505", "#4ecac2",];
var options = {
    chart: {
        height: 320,
        type: 'donut',
    },
    dataLabels: {
        enabled: false
    },
    labels: ["سری 1" , "سری 2" , "سری 3" , "سری 4", "سری 5"],
    series: [44, 55, 13, 33],
    colors: colors,
    legend: {
        show: true,
        position: 'bottom',
        horizontalAlign: 'center',
        verticalAlign: 'middle',
        floating: false,
        fontSize: '14px',
        offsetX: 0,
        offsetY: 7
    },
    responsive: [{
        breakpoint: 600,
        options: {
            chart: {
                height: 240
            },
            legend: {
                show: false
            },
        }
    }]
}
var chart = new ApexCharts(
    document.querySelector("#update-donut"),
    options
);
chart.render();

function appendData() {
    var arr = chart.w.globals.series.map(function () {
        return Math.floor(Math.random() * (100 - 1 + 1)) + 1;
    });
    arr.push(Math.floor(Math.random() * (100 - 1 + 1)) + 1);
    return arr;
}

function removeData() {
    var arr = chart.w.globals.series.map(function () {
        return Math.floor(Math.random() * (100 - 1 + 1)) + 1;
    });
    arr.pop();
    return arr;
}

function randomize() {
    return chart.w.globals.series.map(function () {
        return Math.floor(Math.random() * (100 - 1 + 1)) + 1;
    });
}

function reset() {
    return options.series;
}

document.querySelector("#randomize").addEventListener("click", function () {
    chart.updateSeries(randomize());
});

document.querySelector("#add").addEventListener("click", function () {
    chart.updateSeries(appendData());
});

document.querySelector("#remove").addEventListener("click", function () {
    chart.updateSeries(removeData());
});

document.querySelector("#reset").addEventListener("click", function () {
    chart.updateSeries(reset());
});

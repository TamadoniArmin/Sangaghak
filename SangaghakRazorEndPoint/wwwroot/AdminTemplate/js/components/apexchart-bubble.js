/**
 * قالب: لارکن - داشبورد مدیریت ریسپانسیو بوت‌استرپ ۵
 * نویسنده: تکزا
 * ماژول/اپ: نمودارهای حبابی اپکس
 */

//
// نمودار حبابی ساده
//

/*
// این تابع خروجی را در این قالب تولید می‌کند
// data = [
    [timestamp, 23],
    [timestamp, 33],
    [timestamp, 12]
    ...
]
*/
function generateData(baseval, count, yrange) {
    var i = 0;
    var series = [];
    while (i < count) {
        var x = Math.floor(Math.random() * (750 - 1 + 1)) + 1;
        var y = Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;
        var z = Math.floor(Math.random() * (75 - 15 + 1)) + 15;

        series.push([x, y, z]);
        baseval += 86400000;
        i++;
    }
    return series;
}

var colors = ["#1c84ee", "#7f56da"];
var options = {
    chart: {
        height: 380,
        type: 'bubble',
        toolbar: {
            show: false
        }
    },
    dataLabels: {
        enabled: false
    },
    series: [{
        name: 'حباب ۱',
        data: generateData(new Date('۱ آبان ۱۴۰۲').getTime(), 20, {
            min: 10,
            max: 60
        })
    },
    {
        name: 'حباب ۲',
        data: generateData(new Date('۱ آبان ۱۴۰۲').getTime(), 20, {
            min: 10,
            max: 60
        })
    },
    {
        name: 'حباب ۳',
        data: generateData(new Date('۱ آبان ۱۴۰۲').getTime(), 20, {
            min: 10,
            max: 60
        })
    }
    ],
    fill: {
        opacity: 0.8,
        gradient: {
            enabled: false
        }
    },
    colors: colors,
    xaxis: {
        tickAmount: 12,
        type: 'category',
    },
    yaxis: {
        max: 70
    },
    grid: {
        borderColor: '#f1f3fa',
        padding: {
            bottom: 5
        }
    },
    legend: {
        offsetY: 7,
    }
}

var chart = new ApexCharts(
    document.querySelector("#simple-bubble"),
    options
);

chart.render();



//
// 3D BUBBLE CHART
//

/*
// this function will generate output in this format
// data = [
    [timestamp, 23],
    [timestamp, 33],
    [timestamp, 12]
    ...
]
*/
function generateData1(baseval1, count, yrange) {
    var i = 0;
    var series = [];
    while (i < count) {
        //var x =Math.floor(Math.random() * (750 - 1 + 1)) + 1;;
        var y = Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;
        var z = Math.floor(Math.random() * (75 - 15 + 1)) + 15;

        series.push([baseval1, y, z]);
        baseval1 += 86400000;
        i++;
    }
    return series;
}

var colors = ["#1c84ee", "#7f56da", "#ff6c2f", "#4ecac2"];
var options2 = {
    chart: {
        height: 380,
        type: 'bubble',
        toolbar: {
            show: false
        }
    },
    dataLabels: {
        enabled: false
    },
    series: [{
        name: 'محصول 1',
        data: generateData1(new Date('23 Oct 2023 GMT').getTime(), 20, {
            min: 10,
            max: 80
        })
    },
    {
        name: 'محصول 2',
        data: generateData1(new Date('23 Oct 2023 GMT').getTime(), 20, {
            min: 10,
            max: 80
        })
    },
    {
        name: 'محصول 3',
        data: generateData1(new Date('23 Oct 2023 GMT').getTime(), 20, {
            min: 10,
            max: 80
        })
    },
    {
        name: 'محصول 4',
        data: generateData1(new Date('23 Oct 2023 GMT').getTime(), 20, {
            min: 10,
            max: 80
        })
    }
    ],
    fill: {
        type: 'gradient',
    },
    colors: colors,
    xaxis: {
        tickAmount: 12,
        type: 'datetime',
        labels: {
            rotate: 0,
            formatter: function (value) {
                return "1403"
            }
        }
    },
    yaxis: {
        max: 70
    },
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
    document.querySelector("#second-bubble"),
    options2
);

chart.render();
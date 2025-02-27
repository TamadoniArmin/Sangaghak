//Basic
if (document.getElementById("sweetalert-basic"))
    document.getElementById("sweetalert-basic").addEventListener("click", function () {
        Swal.fire({
            title: 'هر کسی می‌تواند از کامپیوتر استفاده کند',
            customClass:{
                confirmButton: 'btn btn-primary w-xs mt-2'
            },
            confirmButtonText:"باشه",
            buttonsStyling: false,
            showCloseButton: false
        })
    });

//A title with a text under
if (document.getElementById("sweetalert-title"))
    document.getElementById("sweetalert-title").addEventListener("click", function () {
        Swal.fire({
            title: "اینترنت ؟",
            text: 'اینورا هم پیدا میشه ؟',
            icon: 'question',
            customClass: {
                confirmButton: 'btn btn-primary w-xs mt-2'
            },
            confirmButtonText: "باشه",
            buttonsStyling: false,
            showCloseButton: false
        })
    });

//Success Message
if (document.getElementById("sweetalert-success"))
    document.getElementById("sweetalert-success").addEventListener("click", function () {
        Swal.fire({
            title: 'آفرین',
            text: 'کلیک کردی',
            icon: 'success',
            showCancelButton: true,
            confirmButtonClass: '',
            cancelButtonClass: '',
            customClass: {
                confirmButton: 'btn btn-primary w-xs me-2 mt-2',
                cancelButton: 'btn btn-danger w-xs mt-2'
            },
            confirmButtonText: "باشه",
            cancelButtonText: "نه",
            buttonsStyling: false,
            showCloseButton: false
        })
    });

//error Message
if (document.getElementById("sweetalert-error"))
    document.getElementById("sweetalert-error").addEventListener("click", function () {
        Swal.fire({
            title: 'اووپس',
            text: 'یه چیزی اشتباه شده',
            icon: 'error',
            customClass: {
                confirmButton: 'btn btn-primary w-xs mt-2'
            },
            confirmButtonText: "باشه",
            buttonsStyling: false,
            footer: '<a href="">چرا من این مشکل را دارم ؟</a>',
            showCloseButton: false
        })
    });

//info Message
if (document.getElementById("sweetalert-info"))
    document.getElementById("sweetalert-info").addEventListener("click", function () {
        Swal.fire({
            title: 'اوops...',
            text: 'یه چیزی اشتباه شده!',
            icon: 'info',
            customClass: {
                confirmButton: 'btn btn-primary w-xs mt-2'
            },
            confirmButtonText: "باشه",
            buttonsStyling: false,
            footer: '<a href="">چرا من این مشکل را دارم ؟</a>',
            showCloseButton: false
        })
    });

//Warning Message
if (document.getElementById("sweetalert-warning"))
    document.getElementById("sweetalert-warning").addEventListener("click", function () {
        Swal.fire({
            title: 'اوops...',
            text: 'یه چیزی اشتباه شده!',
            icon: 'warning',
            customClass: {
                confirmButton: 'btn btn-primary w-xs mt-2'
            },
            confirmButtonText: "باشه",
            buttonsStyling: false,
            footer: '<a href="">چرا من این مشکل را دارم ؟</a>',
            showCloseButton: false
        })
    });

// long content
if (document.getElementById("sweetalert-longcontent"))
    document.getElementById("sweetalert-longcontent").addEventListener("click", function () {
        Swal.fire({
            imageUrl: 'https://placeholder.pics/svg/300x1500',
            imageHeight: 1500,
            imageAlt: 'یک تصویر بلند',
            customClass: {
                confirmButton: 'btn btn-primary w-xs mt-2'
            },
            confirmButtonText: "باشه",
            buttonsStyling: false,
            showCloseButton: false
        })
    });

//Parameter
if (document.getElementById("sweetalert-params"))
    document.getElementById("sweetalert-params").addEventListener("click", function () {
        Swal.fire({
            title: 'آیا مطمئن هستید؟',
            text: "شما نمی‌توانید این را برگردانید!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'بله، حذفش کن!',
            cancelButtonText: 'نه، لغو کن!',
            customClass: {
                confirmButton: 'btn btn-primary w-xs me-2 mt-2',
                cancelButton: 'btn btn-danger w-xs mt-2'
            },
            confirmButtonText: "باشه",
            cancelButtonText: "نه",
            buttonsStyling: false,
            showCloseButton: false
        }).then(function (result) {
            if (result.value) {
                Swal.fire({
                    title: 'حذف شد!',
                    text: 'فایل شما حذف شده است.',
                    icon: 'success',
                    customClass: {
                        confirmButton: 'btn btn-primary w-xs mt-2'
                    },
                    confirmButtonText: "باشه",
                    buttonsStyling: false
                })
            } else if (
                // درباره مدیریت انصراف بیشتر بخوانید
                result.dismiss === Swal.DismissReason.cancel
            ) {
                Swal.fire({
                    title: 'لغو شد',
                    text: 'فایل خیالی شما در امان است :)',
                    icon: 'error',
                    customClass: {
                        confirmButton: 'btn btn-primary w-xs mt-2'
                    },
                    confirmButtonText: "باشه",
                    buttonsStyling: false
                })
            }
        });
    });

//Custom Image
if (document.getElementById("sweetalert-image"))
    document.getElementById("sweetalert-image").addEventListener("click", function () {
        Swal.fire({
            title: 'عالی!',
            text: 'مدالی با یک تصویر سفارشی.',
            imageUrl: 'assets/images/logo-sm.png',
            imageHeight: 40,
            customClass: {
                confirmButton: 'btn btn-primary w-xs mt-2'
            },
            confirmButtonText: "باشه",
            buttonsStyling: false,
            animation: false,
            showCloseButton: false
        })
    });

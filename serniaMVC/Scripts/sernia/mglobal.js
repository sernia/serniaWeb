$(document).ready(function () {
    //メニュー設定
    $('.globalMenu').click(function () {
        $('.navMenu').animate({left : '0'}, 25);
    })

    $('.navMenuClose').click(function () {
        $('.navMenu').animate({ left: '-150' }, 25);
    });

    $('.menuList ul li').mouseover(function () {
        $(this).animate({ backgroundColor: '#000', color: '#FFF' }, 150);
    }).mouseout(function () {
        $(this).animate({ backgroundColor: '#FFF', color: '#000' }, 10);
    }).click(function () {
        urlSet($(this).text());
    });
});

function urlSet(v) {
    var text = v;
    switch (text) {
        case "Top":
            window.location.href = '/';
            break;
        case "sernia":
            window.location.href = '/ja/sernia/';
            break;
        case "develop":
            window.location.href = '/ja/dev/1';
            break;
        case "news":
            window.location.href = '/ja/new/';
            break;
        case "devSite":
            window.location.href = '/ja/site/';
            break;
    }
}
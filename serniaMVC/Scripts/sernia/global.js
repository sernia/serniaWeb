$(document).ready(function () {
    //メニュー設定
    $('.globalMenu').mouseover(function () {
        $('.menuList ul').animate({ opacity: 'show' }, 150);
        $('.icono-hamburger').animate({ color: '#AAA' }, 10);
    }).mouseout(function () {
        
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
        case "H":
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


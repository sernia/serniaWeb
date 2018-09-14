$(document).ready(function () {
    //メニュー設定
    $('.ulTopMenu li').mouseover(function () {
        $(this).animate({ backgroundColor: '#000', color: '#FFF' }, 150);
    }).mouseout(function () {
        $(this).animate({ backgroundColor: '#FFF', color: '#000' }, 10);
    }).click(function () {
        urlSet($(this).text());
    });
});
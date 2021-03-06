﻿function BootstrapSlider() {
    
    $('.t1').after('<div id="nav" class="text-center"></div>');
    var rowsShown = 4;
    var rowsTotal = $('.t1 .row .filter').length; console.log(rowsTotal);
    var numPages = rowsTotal / rowsShown;
    for (i = 0; i < numPages; i++) {
        var pageNum = i + 1;
        $('#mypage').append('<li><a href="#" class="" rel="' + i + '">&emsp;' + pageNum + '&emsp;</a></li>');
    }
    $('.t1 .row .filter').hide();
    $('.t1 .row .filter').slice(0, rowsShown).show();
    $('#mypage a:first').addClass('active');
    $('#mypage a').bind('click', function (e) {
        e.preventDefault();
        $('#mypage a').removeClass('active');
        $(this).addClass('active');
        var currPage = $(this).attr('rel');
        var startItem = currPage * rowsShown;
        var endItem = startItem + rowsShown;
        $('.t1 .row .filter').css('opacity', '0').hide().slice(startItem, endItem).
            css('display', 'flex').animate({
                opacity: 1
            }, 300);
    });
}

function ProductFilter()
{
    var url = window.location.href;
    var test = url.split("/"); test = test.pop(); test = test.trim();
    
    if (test === "products") {

    }
    else {
        $('#filters button').not("#" + test).hide();
    }
}

function Fillcategory() {
    $.ajax({
        type: "GET",
        url: "/api/cart/fillcategory",
        async: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: {}
        ,
        success: function (data) {
            alert(data);
            console.log(data);
            toastr.success('Item added to cart');
        },
        error: function (a, b, c) {
            alert(a);
            toastr.error('Error occurred'); return false;
        }

    });
}

function UpdateQuantity(itemindex, productid, quantity, flag) {
    var s = new Object();
    s.RowId = itemindex;
    s.ProductID = productid;
    s.quantity = quantity;

    $.ajax({
        type: "POST",
        url: "/api/cart/QuantityUpdate",
        async: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(s)
        ,
        success: function (data) {
            var cartdata = JSON.parse(data);
            $("#txtsubtotal").text(cartdata.SubTotal);
            $("#txtfinaltotal").text(cartdata.FinalTotal);
            var temp = "#linetotal" + productid;
            $(temp).text(cartdata.Items[itemindex].Linetotal);
            if (flag == 1)
                toastr.success('Item quantity decreased in cart');
            else
                toastr.success('Item quantity increased in cart');
        },
        error: function (a, b, c) {
            //toastr.error('Error occurred'); return false;
        }

    });
}

function GetCart() {

    $.ajax({
        type: "GET",
        url: "/api/cart/getcart",
        async: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: {}
        ,
        success: function (data) {
            var l = JSON.parse(data);
            var n = l == null ? 0 : l["Items"].length;
            $("#qty").text(n);

        },
        error: function (a, b, c) {
          
            toastr.error('Error occurred'); return false;
        }

    });
}

//will load objects to dom
$(document).ready(function () {
    $(".quantity-left-minus").click(function () {
        var productid = $(this).attr("alt"); //get quantity textbox value
        var txtname = '#qty' + productid;  //concat
        var quantity = $(txtname).val();  //get quantity textbox value
        c = --quantity;
        var itemindex = $(txtname).attr("alt"); //get item index

        if (c > 0) {
            $(txtname).val(c); //load quantity to textbox
            UpdateQuantity(itemindex, productid, c,1);
        }
    });
    $(".quantity-right-plus").click(function () {
        
        var productid = $(this).attr("alt");  //get product id
        var txtname = '#qty' + productid;  //concat
        var quantity = $(txtname).val();  //get quantity textbox value
        c = ++quantity;                      // update quantity
        var itemindex = $(txtname).attr("alt"); //get item index

        if (c < 250) {
            $(txtname).val(c); //load quantity to textbox
            UpdateQuantity(itemindex,productid,c,2);
        }
    });
 
    $("#btnm").click(function () {
        
        var a = $("#quantity").val();
        b = --a;
        if (b > 0) {
            $("#quantity").val(b); toastr.success('Item quantity decreased in cart');
        }
    });
    $("#btnp").click(function () {
        
        var a = $("#quantity").val();
        b = ++a;
        if (b < 250) {
            $("#quantity").val(b); toastr.success('Item quantity increased in cart');
        }
    });

    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });

    $(".dela").click(function () {
        var s = new Object();
        var pid = $(this).attr("alt");
        s.ProductId = pid; //get product id

        $.ajax({
            type: "POST",
            url: "/api/cart/deleteitem",
            async: false,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(s)
            ,
            success: function (data) {
                var f = "#tr" + pid;
                $(f).remove();
                var cartdata = JSON.parse(data);
                $("#txtsubtotal").text(cartdata.SubTotal);
                $("#txtfinaltotal").text(cartdata.FinalTotal);
                GetCart();
                toastr.success('Item removed from cart');
            },
            error: function (data) {
                toastr.error('Error occurred'); return false;
            }

        });
    });

    $(".addsingle").click(function () {
        var pid = $(this).attr("alt");

        $.ajax({
            type: "GET",
            url: "/api/cart/singleitemadd",
            async: false,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: { 'id': pid }
            ,
            success: function (data) {
                GetCart();
                toastr.success('Item added to cart');
            },
            error: function (a, b, c) {

                toastr.error('Error occurred'); return false;
            }

        });
    });

    $('#filters').on('click', 'button', function () {

        $('#filters button').removeClass('active');
        $(this).addClass('active');
        var value = $(this).attr('data-filter');

        if (value == "*") {
            $('.filter').show('3000');
        }
        else {
            $(".filter").not(value).hide('3000');
            $('.filter').filter(value).show('3000');
        }
    });

});
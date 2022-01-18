// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let cards = new Array();
$(document).ready(
    function () {
        $(".document").each(
            function () {
                var title = this.dataset.documentId;
                var contents = this.dataset.documentContents;

                var card = new documentCard(title, contents);

                cards.push(card);
            }
        );

        var infoPanelHtml;

        $(cards).each(
            function () {
                infoPanelHtml = "<div class='cardElement'><h3>Document Info</h3><div class='title'>Title: " + this.title + "</div>";
                infoPanelHtml += "<div class='contents'>Contents: " + this.contents + "</div>";
                infoPanelHtml += "<div class='length'>Document Length: " + this.length + "</div></div>";

                $(".infopanel").html(infoPanelHtml);
            }
        );
    }
);
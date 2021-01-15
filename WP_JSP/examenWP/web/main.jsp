<%--
  Created by IntelliJ IDEA.
  User: Florinel-PC
  Date: 25-Jun-20
  Time: 10:12 AM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Title</title>
    <style>
        .asset-name {
            background-color: cornflowerblue;
            border-right: solid 1px black;
        }
    </style>
    <script src="js/jquery-3.5.1.js"></script>
    <script src="js/utils.js"></script>
</head>
<body>
<br/>
<p><button id="getAssets" type="button">Get Assets</button></p>
<section><table id="assets-table"></table></section>
<p style="height: 50px;"></p>
<section>
    <label>Doc Name (it's unique) </label><input type="text" name="documentName" id="documentName"><br>
    <label>Keyword1 </label><input type="text" name="documentKeyword1" id="documentKeyword1"><br>
    <label>Keyword2 </label><input type="text" name="documentKeyword2" id="documentKeyword2"><br>
    <label>Keyword3 </label><input type="text" name="documentKeyword3" id="documentKeyword3"><br>
    <label>Keyword4 </label><input type="text" name="documentKeyword4" id="documentKeyword4"><br>
    <label>Keyword5 </label><input type="text" name="documentKeyword5" id="documentKeyword5"><br>
    <button id="updateKeywords" type="button">Update keywords for this document</button>
</section>

<p><button id="getWebsite" type="button">Get Assets</button></p>
<section><table id="websites-table"></table></section>
<script>
    $(document).ready(function () {
        $("#getAssets").click(function () {
            getDocuments(function (assets) {
                console.log(assets);
                $("#assets-table").html("");
                $("#assets-table").append("<tr style='background-color: mediumseagreen'><td>Id</td><td>idWebSite</td><td>Name</td><td>Keyword1</td><td>Keyword2</td><td>Keyword3</td><td>Keyword4</td><td>Keyword5</td></tr>");
                for (var name in assets) {
                    $("#assets-table").append("<tr><td class='asset-name'>" + assets[name].id + "</td>" +
                        "<td>" + assets[name].idWebSite + "</td>" +
                        "<td>" + assets[name].name + "</td>" +
                        "<td>" + assets[name].keyword1 + "</td>" +
                        "<td>" + assets[name].keyword2 + "</td>" +
                        "<td>" + assets[name].keyword3 + "</td>" +
                        "<td>" + assets[name].keyword4 + "</td>" + "<td>" + assets[name].keyword5 + "</td></tr>"
                    );
                }
            })
        });

        $("#updateKeywords").click(function () {
            updateKeywordsForDocument($("#documentName").val(), $("#documentKeyword1").val(), $("#documentKeyword2").val(), $("#documentKeyword3").val(), $("#documentKeyword4").val(), $("#documentKeyword5").val(),
                function (courses) {
                    $("#maindiv").html("it worked");
                });
        });

        $(document).ready(function () {
            $("#getWebsite").click(function () {
                getWebsites(function (assets) {
                    console.log(assets);
                    $("#websites-table").html("");
                    $("#websites-table").append("<tr style='background-color: mediumseagreen'><td>Id</td><td>url</td><td>no. of docs</td></tr>");
                    for (var name in assets) {
                        $("#websites-table").append("<tr><td class='asset-name'>" + assets[name].id + "</td>" +
                            "<td>" + assets[name].url + "</td>" +
                            "<td>" + assets[name].noOfDocs + "</td></tr>"
                        );
                    }
                })
            });
        });
    });

</script>
</body>
</html>

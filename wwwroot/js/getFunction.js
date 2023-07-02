$(document).ready(function () {
    GetNationality();
    GetReligion();
    GetCategory();
    GetState();
    GetDistrict();
    GetBlock();
    GetVillage();
    GetStatus();

});






function GetStatus() {
    $.ajax({
        url: '/ApplicantMbbs/Status',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Status').append('<option value=' + data.applicationStatus + '>' + data.applicationStatusDesc + '</option>')
               
            });
        }
    });
}
function GetNationality() {

    var item = $("#Nationality").val();

    $.ajax({
        url: '/ApplicantMbbs/GetNationalityName?id=' + item,
        success: function (result) {

            $("#Nationality").val(result[0].nationalityName);
        }
    });
}
function GetReligion() {

    var item = $("#Religion").val();


    $.ajax({
        url: '/ApplicantMbbs/GetReligionName?id=' + item,
        success: function (result) {
            $("#Religion").val(result[0].religionDesc);
        }
    });
}
function GetCategory() {

    var item = $("#Category").val();


    $.ajax({
        url: '/ApplicantMbbs/GetCategoryName?id=' + item,
        success: function (result) {

            $("#Category").val(result[0].categoryDesc);
        }
    });
}
function GetState() {

    var per = $("#PerState").val();
    var pre = $("#PreState").val();
    $.ajax({
        url: '/ApplicantMbbs/GetStateName?id=' + per,
        success: function (result) {
            $("#PerState").val(result[0].stateName);
        }
    });
    $.ajax({
        url: '/ApplicantMbbs/GetStateName?id=' + pre,
        success: function (result) {
            $("#PreState").val(result[0].stateName);
        }
    });
}
function GetDistrict() {
    var per = $("#PerDistrict").val();
    var pre = $("#PreDistrict").val();
    $.ajax({
        url: '/ApplicantMbbs/GetDistrictName?id=' + per,
        success: function (result) {
            $("#PerDistrict").val(result[0].districtName);
        }
    });
    $.ajax({
        url: '/ApplicantMbbs/GetDistrictName?id=' + pre,
        success: function (result) {
            $("#PreDistrict").val(result[0].districtName);
        }
    });
}

function GetBlock() {

    var per = $("#PerBlock").val();
    var pre = $("#PreBlock").val();

    $.ajax({
        url: '/ApplicantMbbs/GetBlockName?id=' + per,
        success: function (result) {

            $("#PerBlock").val(result[0].blockName);
        }
    });
    $.ajax({
        url: '/ApplicantMbbs/GetBlockName?id=' + pre,
        success: function (result) {
            $("#PreBlock").val(result[0].blockName);
        }
    });
}

function GetVillage() {

    var per = $("#PerVillage").val();
    var pre = $("#PreVillage").val();

    $.ajax({
        url: '/ApplicantMbbs/GetVillageName?id=' + per,
        success: function (result) {
            $("#PerVillage").val(result[0].villageName);
        }
    });

    $.ajax({
        url: '/ApplicantMbbs/GetVillageName?id=' + pre,
        success: function (result) {
            $("#PreVillage").val(result[0].villageName);
        }
    });
}

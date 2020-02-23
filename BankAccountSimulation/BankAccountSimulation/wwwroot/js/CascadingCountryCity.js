$(document).ready(function () {
    $("#CountryId").change(function () {
        var countryId = $("#CountryId").val();
        $("#CityId").empty();
        $("#CityId").append('<option value="">-- Select City --</option>');
        var serverUrl = '/api/Branch/GetCityByCountryId?countryId=' + countryId;

        $.ajax({
            url: serverUrl,
            success: function (response) {
                $.each(response, (index, value) => {
                    $("#CityId").append('<option value=' + value.id + '>' + value.name + '</option>');
                });
            },
            error: function (response) {
                alert(response);
            }
        });
    });
});
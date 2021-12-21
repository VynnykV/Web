jQuery(document).ready(function($) {
    jQuery.getScript('http://www.geoplugin.net/javascript.gp', function() 
    {
        $('#country').val(geoplugin_countryName());
        $('#city').val(geoplugin_city());
    });
});
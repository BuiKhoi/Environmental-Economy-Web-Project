
// The location of Danang
//var dad = { lat: 16.061195, lng: 108.228185 };
var map;
var heatmap;
var circle = null;
var infowindow = null;

function Scope(latitude, longitude, radius) {
    this.latitude = latitude;
    this.longitude = longitude;
    this.radius = radius;
}

function GetCoor(str, radius) {
    var len = str.length;
    str = str.slice(1, len - 1);
    str = str.split(", ");
    str[0] = parseFloat(str[0]);
    str[1] = parseFloat(str[1]);
    coo = new Scope(str[0], str[1], radius);
    return coo;
}

function initMap() {
    // The map, centered at Danang
    map = new google.maps.Map(
        document.getElementById('map'), { zoom: 15, center: InitLocation });

    heatmap = new google.maps.visualization.HeatmapLayer({
        data: getPoints(),
        map: map,
        //gradient: getGradient()
    });

    map.addListener('click', function (e) {
        //placeMarkerAndPanTo(e.latLng, map);
        if (circle != null) {
            circle.setMap(null);
        }
        circle = new google.maps.Circle({
            strokeColor: '#ed370e',
            strokeOpacity: 0.6,
            strokeWeight: 2,
            fillColor: '#b6e552',
            fillOpacity: 0.35,
            map: map,
            center: e.latLng,
            radius: 300,
            editable: true
        });
        map.panTo(e.latLng);
        SendScope(circle);

        circle.addListener('radius_changed', function (e) {
            SendScope(circle);
        });

        circle.addListener('center_changed', function (e) {
            map.panTo(circle.getCenter());
            SendScope(circle);
        });

        circle.addListener('click', function () {
            SendScope(circle);
        })
    });

    var input = document.getElementById('txtSearch');
    var searchBox = new google.maps.places.SearchBox(input);
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    // Bias the SearchBox results towards current map's viewport.
    map.addListener('bounds_changed', function () {
        searchBox.setBounds(map.getBounds());
    });

    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener('places_changed', function () {
        var places = searchBox.getPlaces();
        console.log(places.length);
        var coo = GetCoor(places[0].geometry.location.toString(), 0);
        console.log(coo);
        map.panTo(new google.maps.LatLng(coo.latitude, coo.longitude));
        if (circle != null) {
            circle.setMap(null);
        }
        circle = new google.maps.Circle({
            strokeColor: '#ed370e',
            strokeOpacity: 0.6,
            strokeWeight: 2,
            fillColor: '#b6e552',
            fillOpacity: 0.35,
            map: map,
            center: new google.maps.LatLng(coo.latitude, coo.longitude),
            radius: 300,
            editable: true
        });
        SendScope(circle);
        //map.fitBounds(bounds);
    });
}

function placeMarkerAndPanTo(latLng, map) {
    var marker = new google.maps.Marker({
        position: latLng,
        map: map
    });
    map.panTo(latLng);
}

function PanCurrentLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(getPos);
    }
}

function getPos(position) {
    console.log("Latitude: " + position.coords.latitude +
        "\nLongitude: " + position.coords.longitude);
    map.panTo(new google.maps.LatLng(position.coords.latitude, position.coords.longitude));
}

function getGradient() {
    return [
        'rgba(0, 255, 255, 0)',
        'rgba(0, 255, 255, 1)',
        'rgba(0, 191, 255, 1)',
        'rgba(0, 127, 255, 1)',
        'rgba(0, 63, 255, 1)',
        'rgba(0, 0, 255, 1)',
        'rgba(0, 0, 223, 1)',
        'rgba(0, 0, 191, 1)',
        'rgba(0, 0, 159, 1)',
        'rgba(0, 0, 127, 1)',
        'rgba(63, 0, 91, 1)',
        'rgba(127, 0, 63, 1)',
        'rgba(191, 0, 31, 1)',
        'rgba(255, 0, 0, 1)'
    ];
}

function distance(lat1, lon1, lat2, lon2) {
    var R = 6371; // km (change this constant to get miles)
    var dLat = (lat2 - lat1) * Math.PI / 180;
    var dLon = (lon2 - lon1) * Math.PI / 180;
    var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2);
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = R * c;
    return Math.round(d * 1000);
}
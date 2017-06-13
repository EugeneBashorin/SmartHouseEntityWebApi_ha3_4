function sendAjaxOn(device) {
    //debugger;
    $.ajax({
        url: '/api/values/OnState',
        type: 'PUT',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(device),
        success: function (result) {
            //debugger;
            $.ajax({
                url: '/SmartHouse/RenderState',
                type: 'GET',
                contentType: 'application/html; charset=utf-8',
                data: result,
                success: function (partial) {
                    $("#state_" + result.Name).html(partial);
                }
            });
        }
    });
}
    function sendAjaxOff(device) {
        //debugger;
        $.ajax({
            url: '/api/values/OffState',
            type: 'PUT',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(device),
            success: function (result) {
                //debugger;
                $.ajax({
                    url: '/SmartHouse/RenderState',
                    type: 'GET',
                    contentType: 'application/html; charset=utf-8',
                    data: result,
                    success: function (partial) {
                        $("#state_" + result.Name).html(partial);
                    }
                });
            }
        });
    }

//SetTemperature
    function sendAjaxSetTemp(device) {
        //debugger;
        $.ajax({
            url: '/api/values/SetTemp/' + $('#warmTemper').val(),
            type: 'PUT',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(device),
            success: function (result) {
                //debugger;
                $.ajax({
                    url: '/SmartHouse/RenderState',
                    type: 'GET',
                    contentType: 'application/html; charset=utf-8',
                    data: result,
                    success: function (partial) {
                        $("#state_" + result.Name).html(partial);
                    }
                });
            }
        });
    }

//IncreaseTemperature
    function sendAjaxIncTemp(device) {
        //debugger;
        $.ajax({
            url: '/api/values/IncTemp',
            type: 'PUT',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(device),
            success: function (result) {
                //debugger;
                $.ajax({
                    url: '/SmartHouse/RenderState',
                    type: 'GET',
                    contentType: 'application/html; charset=utf-8',
                    data: result,
                    success: function (partial) {
                        $("#state_" + result.Name).html(partial);
                    }
                });
            }
        });
    }

//DecreaseTemperature
    function sendAjaxDecTemp(device) {
        //debugger;
        $.ajax({
            url: '/api/values/DecTemp',
            type: 'PUT',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(device),
            success: function (result) {
                //debugger;
                $.ajax({
                    url: '/SmartHouse/RenderState',
                    type: 'GET',
                    contentType: 'application/html; charset=utf-8',
                    data: result,
                    success: function (partial) {
                        $("#state_" + result.Name).html(partial);
                    }
                });
            }
        });
    }

//SetMode
    function sendAjaxSetMode(device) {
        //debugger;
        $.ajax({
            url: '/api/values/SetMode/' + $('#wMode').val(),
            type: 'PUT',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(device),
            success: function (result) {
                //debugger;
                $.ajax({
                    url: '/SmartHouse/RenderState',
                    type: 'GET',
                    contentType: 'application/html; charset=utf-8',
                    data: result,
                    success: function (partial) {
                        $("#state_" + result.Name).html(partial);
                    }
                });
            }
        });
    }

//function Metod(objectVal,index) {
//    $("#on-" + index).click(
//        function () {
//        debugger;
//        $.ajax({
//            url: '/api/values/OnState',
//            type: 'PUT',
//            dataType: 'json',
//            contentType: 'application/json; charset=utf-8',
//            data: JSON.stringify(Json.Encode(objectVal)),
//            success: function (result) {
//                //debugger;
//                $.ajax({
//                    url: '/SmartHouse/RenderState',
//                    type: 'GET',
//                    contentType: 'application/html; charset=utf-8',
//                    data: result,
//                    success: function (partial) {
//                        $("#state_" + result.Name).html(partial);
//                    }
//                });
//            }
//        });
//     }
//    );
//} 
//var devId = $("#Index-" + item.Id).val() 
//var command = $("#command-" + id).val()

function Action(id) {
    var devName = $("#devName-" + id).val()

    $("#on-" + id).click(function (e) {
        e.preventDefault();
        debugger;
            $.ajax({
                url: '/api/values/' + id + '/on',
                type: "PUT",
                success: function (data) {
                    debugger;
                    var src;
                        src = "/Content/image/on" + devName + ".png"
                    $("#state-" + id).attr("src", src)
                    $("#conditionRow-" + id).html(data);
                }
            });
    });

    $("#off-" + id).click(function (e) {
        e.preventDefault();
        debugger;
        $.ajax({
            url: '/api/values/' + id + '/off',
            type: "PUT",
            success: function (data) {
                debugger;
                var src;
                    src = "/Content/image/off" + devName + ".png"
                $("#state-" + id).attr("src", src)
                $("#conditionRow-" + id).html(data);
            }
        });
    });
   
    $("#incT-" + id).click(function (e) {
        e.preventDefault();
        debugger;
        $.ajax({
            url: '/api/values/' + id + '/IncTemp',
            type: "PUT",
            success: function (data) {
                debugger;               
                $("#conditionRow-" + id).html(data);
            }
        });
    });

    $("#decT-" + id).click(function (e) {
        e.preventDefault();
        debugger;
        $.ajax({
            url: '/api/values/' + id + '/DecTemp',
            type: "PUT",
            success: function (data) {
                debugger;
                $("#conditionRow-" + id).html(data);
            }
        });
    });

    //HandSetParams
    $("#setParam-" + id).click(function (e) {
        e.preventDefault();
        var command = $("#InputCommand-" + id).val()
        debugger;
        $.ajax({
            url: '/api/values/' + id + '/' + command + '/' + $('#handSetPar-' + command + id).val(),
            type: 'PUT',
            success: function (data) {
                debugger;
                $("#conditionRow-" + id).html(data);
            }
        });
    });

    //DELETE
    $("#del-" + id).click(function (e) {
        e.preventDefault();
        debugger;
        $.ajax({
            url: '/api/values/Delete/' + id,
            type: 'DELETE',
            success: function () {
                $("#dev-" + id).remove();
            }
        });
    });


   
    
    ////AC Mode
    //function sendAjaxSetMode(id, command) {
    //    //debugger;
    //    $.ajax({
    //        url: '/api/values/SetMode/' + $('#wMode').val(),
    //        type: 'PUT',
    //        success: function (result) {
    //            //debugger;
    //            $.ajax({
    //                url: '/SmartHouse/RenderState' + $("#deviceName-" + id).val(),
    //                type: 'POST',
    //                contentType: 'application/html; charset=utf-8',
    //                data: result,
    //                success: function (partial) {
    //                    $("#result-" + id).html(partial);
    //                }
    //            });
    //        }
    //    });
    //}

    //Bright MODE
    //function sendAjaxSetBright(id) {
    //    //debugger;
    //    $.ajax({
    //        url: '/api/values/SetBright/' + $("#brMode option:selected").text(),
    //        type: 'PUT',
    //        success: function (result) {
    //            //debugger;
    //            $.ajax({
    //                url: '/SmartHouse/RenderState' + $("#deviceName-" + id).val(),
    //                type: 'POST',
    //                contentType: 'application/html; charset=utf-8',
    //                data: result,
    //                success: function (partial) {
    //                    $("#result-" + id).html(partial);
    //                }
    //            });
    //        }
    //    });
    //}

}//=>Action

var SetOrderStatus = function (e,h,ppvs) {
    var ans = confirm("Are you sure ?");
    var url = "" + e + "?handler=" + h + "&" + ppvs;
    var orderkey
    var statusid

    if (ans) {
        $.ajax({
            type: "POST",
            //headers: {
            //    RequestVerificationToken:
            //        $('input:hidden[name="__RequestVerificationToken"]').val()
            //},
            url: url,
            //data: ppvs,
            success: function () {
                alert(" Saved.");
            }
        })
    }

    //$(function () {
    //    $('#submit').on('click', function (evt) {
    //        evt.preventDefault();
    //        $.post('', $('form').serialize(), function () {
    //            alert('Posted using jQuery');
    //        });
    //    });
    //});


}

var AddEdit = function (pv, e, h ,p,ppv) {
    var url = "" + e + "?handler=" + h + "&" + p + "=" + pv + "&" + ppv;
    if (pv > 0)
        $('#title').html("تعديل");
    else
        $('#title').html("جديد");

    $("#FormModelDiv").load(url, function () {
        $("#FormModel").modal("show");

    });
}

/******************************************************/
var AddEditGovernment = function (ppv,pv, e, h, p) {
    
    var url = "" + e + "?handler=" + h + "&" + p + "=" + pv + ppv;
    if (pv > 0)
        $('#title').html("تعديل");
    else
        $('#title').html("جديد");

    $("#FormModelDiv").load(url, function () {
        $("#FormModel").modal("show");

    });
}
var AddEditLocation = function (ppv, pv, e, h, p) {

    var url = "" + e + "?handler=" + h + "&" + p + "=" + pv + ppv;
    if (pv > 0)
        $('#title').html("تعديل");
    else
        $('#title').html("جديد");

    $("#FormModelDiv").load(url, function () {
        $("#FormModel").modal("show");

    });
}
var Deletethis = function (pv, e, h, p) {
   
    var ans = confirm("Are you sure you want to delete?");
    var url = "" + e + "?handler=" + h + "&" + p + "=" + pv;
    if (ans) {
        $.ajax({
            type: "POST",
            url: url,
            success: function () {
                alert(" record deleted.");
            }
        })
    }
}

/******************************************************/
var AddEditForm = function (ppv, pv, e, h, p) {

    var url = "" + e + "?handler=" + h + "&" + p + "=" + pv + ppv;
    if (pv > 0)
        $('#title').html("تعديل");
    else
        $('#title').html("جديد");

    $("#FormModelDiv").load(url, function () {
        $("#FormModel").modal("show");

    });
}
/******************************************************/

var LoadDiv = function (actionurl, dest) {
    var Divdest = document.getElementById(dest);
    $(Divdest).load(actionurl);
}
/******************************************************/
var FillDropDownList = function (elem, dest, route) {
    //if (event.keyCode != 13)
    //    return;

    if (elem == null || elem == "")
        return;


    var DDLDest = document.getElementsByName(dest);
    var locidvalue = elem;
    var actionurl = route + locidvalue;

    $(DDLDest).empty();
    $.get(actionurl).done(function (results) {

        $(DDLDest).append($('<option value="0" class="font-weight-bold"></option>').val(0).html('--Choose--'));


        if (results == null)
            return;

        
        $.each(results, function (i, result) {
            $(DDLDest).append($('<option></option>').val(result.id).html(result.name));
        });

        
    });

}
/******************************************************/
var LoadOrderItems = function (e, baseurl) {

    //var baseurl = @cntlname;
    var handler = "?handler=OrderItems";
    var parm = "&id=" + e.value;
    var url = baseurl + handler + parm;

    LoadDiv(url, 'orderitems');
}
/******************************************************/
var ShowServiceInfo = function (e) {
    var id = $("input:radio[name=selectedService]:checked").val();
    var ref = $(e).closest('tr').find('input[name="RefId"]').val();
    var prod = $(e).closest('tr').find('input[name="ProId"]').val();

    document.getElementsByName("TaskLocationServices.ReferenceId")[0].value = ref;
    document.getElementsByName("TaskLocationServices.ProductId")[0].value = prod;


    //gets table
    var oTable = document.getElementById('servicesTable');

    //gets rows of table
    var rowLength = oTable.rows.length;

    //loops through rows    
    for (i = 0; i < rowLength; i++) {

        //gets cells of current row  
        var oCells = oTable.rows.item(i).cells;

        //gets amount of cells of current row
        var cellLength = oCells.length;

        //loops through each cell in current row
        for (var j = 0; j < cellLength; j++) {

            // get your cell info here

            var cellVal = oCells.item(j).innerHTML;
            
        }
    }

}
/******************************************************/
var SubmitAction = function (pv, e, h, p){
    var url = "" + e + "?handler=" + h + "&" + p + "=" + pv ;
    fetch(`${url}`, {
        method: 'Post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).catch(error => console.error('Unable to update item.', error));
}
/******************************************************/
var governments = function (i) {

    $.ajax({
        type: 'GET',
        url: '/AppConsumers/ConsumerAddress?handler=GovernmentByCountry&countryId=' + i.value,
        success: function (data) {
            alert(data);
            var $select = $('#GovernmentId');
            $select.html('');
            $.each(data, function (key, entry) {
                $select.append($('<option></option>').attr('value', entry.refId).text(entry.name));
            })
        },
        error: function (error) {
            alert("Error: " + error);
        }
    })
}
/******************************************************/
var datalist = function (i, t, u) {
    var $url = u;
    var $targetDD = t;
    var $parm = i;

    $.ajax({
        type: 'GET',
        url: $url + $parm.value,
        success: function (data) {
            var $select = $($targetDD);
            $select.html('');
            $select.empty();
            $select.append('<option selected="true" disabled>--Choose--</option>');
            $select.prop('selectedIndex', 0);

            $.each(data, function (key, entry) {
                $select.append($('<option></option>').attr('value', entry.refId).text(entry.name));
            })
        },
        error: function (error) {
            alert("Error: " + error);
        }
    })
}
/******************************************************/
/******************************************************/


$(function () {
    $('.timepicker').timepicker({
        timeFormat: 'hh:mm',
        interval: 15,
        //minTime: '10',
        //maxTime: '6:00pm',
        //defaultTime: '11',
        //startTime: '10:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true
    });

    $(".datetimepicker").datetimepicker({
        format: "mm/dd/yyyy HH:ii P",
        autoclose: true,
        todayBtn: true,
        startDate: new Date(new Date().setFullYear(new Date().getFullYear() - 1)),
        minuteStep: 10
    });

    $(".datepicker").datepicker({
        format: "yyyy-mm-dd ",
        autoclose: true,
        todayBtn: true,
         minuteStep: 10,
         startDate: new Date(new Date().setFullYear(new Date().getFullYear() - 1)),

    });

});
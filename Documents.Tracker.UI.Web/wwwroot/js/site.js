
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
/******************************************************/
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



var AddTeamMemberHolder = function (id, e) {
    debugger;
    var TeamHeadPrivsel = document.getElementById("TeamHeadPriv");
    var TeamHeadPrivtext = TeamHeadPrivsel.options[TeamHeadPrivsel.selectedIndex].text;
    var TeamHeadPrivvalue = TeamHeadPrivsel.options[TeamHeadPrivsel.selectedIndex].value;

    var TeamMemberssel = document.getElementById("TeamMembers");
    var TeamMemberstext = TeamMemberssel.options[TeamMemberssel.selectedIndex].text;
    var TeamMembersvalue = TeamMemberssel.options[TeamMemberssel.selectedIndex].value;

    var TeamMembersbalancesel = document.getElementById("MemberBalance");
    var TeamMembersbalancevalue = TeamMembersbalancesel.value;

    var table = document.getElementById("TeamMemberHolderTable");
    
    //var actionscell = document.getElementById("actions");

    //var totalRowCount = $("#TeamMemberHolderTable tr").length -2;

    var row = table.insertRow(1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);
    var MeetingDecisionID = $(".MeetingDecisionID").val()
    var meetngId = $("#MeetingId").val()
    $.ajax({
        type: "POST",
        url: "/" + e + "/AddTeamMember?teamid=" + id + "&memberid=" + TeamMembersvalue + "&privid=" + TeamHeadPrivvalue + "&memberbalance=" + TeamMembersbalancevalue + "&meetngId=" + meetngId + "&DicesionID=" + MeetingDecisionID,
        success: function (d) {
            console.log(d)
            if (d.status == false) {
                swal({
                    type: 'error',
                    title: 'Oops...',
                    text: d.msg,
                })
            } else {
                swal("Success!", "Row Added!", "success");
                addrow(d);

            }
        }
    })

    function addrow(d) {
        cell1.innerHTML = TeamHeadPrivtext;
        cell2.innerHTML = TeamMemberstext;
        cell3.innerHTML = TeamMembersbalancevalue;
        cell4.innerHTML = "<input  class='btn btn-sm btn-danger fa fa-remove' type='button' value='delete' onclick='RemoveRow(" + d + ")'/>";

        //cell1.innerHTML = "<input type='hidden' name='MemberPrivlagesMemberPrivId' id='TeamMembers_MemberPrivlagesMemberPrivId' value='" + TeamHeadPrivvalue + "'/>" + TeamHeadPrivtext;
        //cell2.innerHTML = "<input type='hidden' name='MemberId' id='TeamMembers_MemberId' value='" + TeamMembersvalue + "'/>" + TeamMemberstext;
        //cell3.innerHTML =  TeamMembersbalancevalue;
        //cell4.innerHTML = "<input  class='btn btn-sm btn-danger fa fa-remove' type='button' value='delete' onclick='RemoveRow(" + d + ")'/>";
    }
    
}

var AddAchevementFile = function (id,e) {
    debugger;
    var table = document.getElementById("AttachmentTable");
    var row = table.insertRow(1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);

    var title = document.getElementById("FileDescription").value;

    var input = document.getElementById("FilePath");
    var files = input.files;
    var formData = new FormData();

    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]);
    }


    $.ajax({
        type: "POST",
        url: "/" + e + "/AddAchevementsFile",
        data: JSON.stringify(formData),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        processData: false,
        contentType:"application/json",
        success: function (d) {
            swal("Success!", "Row Added!", "success");
            addrow(d);
        }
    })

    function addrow(d) {

        cell1.innerHTML = cell1.innerHTML = "<input type='hidden' name='AchevementsId' value='" + d + "'/>" + title;
        cell2.innerHTML = "<a asp-action='Download' asp-route-filename='@item.FilePath' class='fa fa - download'></a>";
    }
}


function RemoveRow(id) {
    // event.target will be the input element.
    var td = event.target.parentNode;
    var tr = td.parentNode; // the row to be removed
    var MeetingDecisionID = $("#MeetingDecisionID").val()
    var meetngId = $("#MeetingId").val()

    var totalRowCount = $("#TeamMemberHolderTable tr").length;
    if (totalRowCount > 2 && id > 0) {

            $.ajax({
                type: "POST",
                url: "/MeetingManagement/DeleteTeamMember?id=" + id  + "&meetngId=" + meetngId + "&DicesionID=" + MeetingDecisionID,
                success: function () {
                    //$(this).closest('tr').remove()
                    swal("Succes!", "Row Deleted!", "success");
                    tr.parentNode.removeChild(tr);
                }
            })
         
    }
    

}

var DeletethisAttach = function (id, e) {

    var ans = confirm("Are you sure you want to delete?");
    var td = event.target.parentNode;
    var tr = td.parentNode; // the row to be removed

    if (ans) {
        $.ajax({
            type: "POST",
            url: "/" + e + "/DeleteAttachFileId?Id=" + id,
            success: function () {
                swal("Succes!", "File Deleted!", "success");
                tr.parentNode.removeChild(tr);
            }
        })
    }
}

var onMyFrameMeetingLoad = function () {
    $(".iframe").hide()
    $(".iframe").get(0).contentWindow.print();
}

var printMeeting = function (id) {
    var url = "/MeetingManagement/PrintPage?ids=" + id;
    $(".iframe").attr("src", '/Meetinges/printMeeting?id=' + id);
}

var printMeetingCover = function (id) {
    var url = "/MeetingManagement/PrintPage?ids=" + id;
    $(".iframe").attr("src", '/Meetinges/printMeetingCover?id=' + id);
}

var printDecision = function (id, index, count) {
    $(".iframe").attr("src", '/Meetinges/printDecision?id=' + id + "&index=" + index + "&count=" + count);
}

var ManageMembers = function (id, e, t, m) {

    var url = "/" + e + "/ManageTeamMember?id=" + id + "&MainTeamId=" + t + "&meetingid=" + m;
    if (id > 0)
        $('#title').html("تعديل");
    else
        $('#title').html("جديد");

    $("#FormModelDiv").load(url, function () {
        $("#FormModel").modal("show");

    });
}

function formatRepo(repo) {
    if (repo.loading) return repo.text;
    var markup = "<div class='select2-result-repository clearfix'>" +
        "<div class='select2-result-repository__meta'>" +
        "<div class='select2-result-repository__title'>" + repo.full_name + "</div>";
    if (repo.description) {
        markup += "<div class='select2-result-repository__description'>" + repo.description + "</div>";
    }
    markup += "<div class='select2-result-repository__statistics'>" +
        "<div class='select2-result-repository__forks'><i class='fa fa-flash'></i> " + repo.forks_count + " Forks</div>" +
        "<div class='select2-result-repository__stargazers'><i class='fa fa-star'></i> " + repo.stargazers_count + " Stars</div>" +
        "<div class='select2-result-repository__watchers'><i class='fa fa-eye'></i> " + repo.watchers_count + " Watchers</div>" +
        "</div>" +
        "</div></div>";
    return markup;
}
function formatRepoSelection(repo) {
    return repo.full_name || repo.text;
}

//$.fn.modal.Constructor.prototype.enforceFocus = function () { };
//$.fn.modal.Constructor.prototype._enforceFocus = function () { };

$(document).ready(function () {
    $("#kt_select2_6").select2({
        //dropdownParent: $('#FormModel'),
        placeholder: "Search for repositories",
        allowClear: true,
        ajax: {
            url: "https://api.github.com/search/repositories",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    q: params.name, // search term
                    page: params.page
                };
            },
            processResults: function (data, params) {
                // parse the results into the format expected by Select2
                // since we are using custom formatting functions we do not need to
                // alter the remote JSON data, except to indicate that infinite
                // scrolling can be used
                params.page = params.page || 1;

                return {
                    results: data.items,
                    pagination: {
                        more: (params.page * 30) < data.total_count
                    }
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) {
            return markup;
        }, // let our custom formatter work
        minimumInputLength: 1,
        templateResult: formatRepo, // omitted for brevity, see the source of this page
        templateSelection: formatRepoSelection // omitted for brevity, see the source of this page
    });
    //$("#teams").autocomplete({
    //    source: function (request, response) {
    //        $.ajax({
    //            url: "/MeetingManagement/GetTeams",
    //            dataType: "json",
    //            data: {
    //                teamname: request.term
    //            },
    //            success: function (data) {
    //                //response(data);

    //                response($.map(data, function (teams) {
    //                    return {
    //                        label: teams.label,
    //                        value: teams.label,
    //                        TeamId: teams.value,
    //                        DateFrom: teams.dateFrom,
    //                        DateTo: teams.dateTo
    //                    };
    //                }
    //                ));
    //            },
    //            messages: {
    //                noResults: '',
    //                results: function () { }
    //            }
    //        });
    //    },
    //    delay: 1,
    //    minLength: 3,
    //    select: function (event, ui) {
    //        $("#TeamId").val(ui.item.TeamId);
    //        $("#DateFrom").val = ui.item.value;
    //        $("#DateTo").val = ui.item.DateTo;
    //        document.getElementById("DateFrom").value = ui.item.DateFrom;
    //        document.getElementById("DateTo").value = ui.item.DateTo;
    //    }
    //});
    //$("#teams").autocomplete({
    //    source: function (request, response) {
    //        $.ajax({
    //            url: "/MeetingManagement/GetCategory",
    //            dataType: "json",
    //            data: {
    //                teamname: request.term
    //            },
    //            success: function (data) {
    //                //response(data);
                 
    //                 response($.map(data, function (teams) {
    //                     return {
    //                         label: teams.label,
    //                         value: teams.label,
    //                         TeamId: teams.value,
    //                         DateFrom: teams.dateFrom,
    //                         DateTo : teams.dateTo
    //                     };
    //                 }
    //                 ));
    //            },
    //            messages: {
    //                noResults: '',
    //                results: function () { }
    //            }
    //        });
    //    },
    //    delay: 1,
    //    minLength: 3,
    //    select: function (event, ui) {
    //        $("#TeamId").val(ui.item.TeamId);
    //        $("#DateFrom").val = ui.item.value;
    //        $("#DateTo").val = ui.item.DateTo;
    //        document.getElementById("DateFrom").value = ui.item.DateFrom;
    //        document.getElementById("DateTo").value = ui.item.DateTo;
    //    }
    //});
  
    //$("body").on("click", "#savethis", function () {
    //    debugger;
    //    var TeamHeadMembers = new Array();
    //    $('#TeamMemberHolderTable tbody tr').each(function () {
    //        var teamMember = {};
    //        $(this).find("td input:hidden,select").each(function () {
    //            var inputid = $(this).attr("id");
    //            var inputvalue = this.value;
    //            if (inputid == "TeamMembers_MemberPrivlagesMemberPrivId") {
    //                teamMember.MemberPrivlagesMemberPrivId = inputvalue
    //                //textVal = this.value;
    //                //inputName = inputid;
    //            }

    //            if (inputid == "TeamMembers_MemberId") {
    //                teamMember.MemberId = inputvalue
    //                //textVal = this.value;
    //                //inputName = inputid;
    //            }
    //        });
    //        TeamHeadMembers.push(teamMember);
    //    });
    //    //Loop through the Table rows and build a JSON array.
    //    //var TeamHeadMembers = new Array();
    //    //var rows = $("#TeamMemberHolderTable TBODY tr");
    //    //rows.each(function () {
    //    //    var row = $(this);
    //    //    var teamMember = {};

    //    //    var inputMemberPrivlagesMemberPrivId = row.find("#TeamMembers_MemberPrivlagesMemberPrivId").eq(0);
    //    //    var inputMemberId = row.find("#TeamMembers_MemberId").eq(1);
    //    //    teamMember.MemberPrivlagesMemberPrivId = $(inputMemberPrivlagesMemberPrivId).val();
    //    //    teamMember.MemberId = $(inputMemberId).val();
    //    //    TeamHeadMembers.push(teamMember);
    //    //});

    //    //Send the JSON array to Controller using AJAX.
         
    //    var dataOutput = { "modelDTo": TeamHeadMembers };

    //    $.ajax({
    //        type: "POST",
    //        url: "/MeetingManagement/AddEdit",
    //        data: TeamHeadMembers,
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function () {
    //            alert( " record(s) inserted.");
    //        }
    //    });
    //});

   

});

$("#Memberteams").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "/MeetingManagement/GetTeams",
            dataType: "json",
            data: {
                teamname: request.term
            },
            success: function (data) {
                //response(data);

                response($.map(data, function (teams) {
                    return {
                        label: teams.label,
                        value: teams.label,
                        TeamId: teams.value
                    };
                }
                ));
            },
            messages: {
                noResults: '',
                results: function () { }
            }
        });
    },
    delay: 0,
    minLength: 2,
    select: function (event, ui) {
        var teamid = ui.item.TeamId;
        $("#TeamId").val(teamid);

        ChangeTeamMembers(teamid, 'MeetingManagement', teamid, 0);
    }
});



var ViewForm = function (id, e) {

    var url = "/" + e + "/ViewForm?id=" + id;
    $('#title').html("التفاصيل");

    $("#FormModelDiv").load(url, function () {
        $("#FormModel").modal("show");

    });
}

var deleteMeetingDecision = function (id, e) {
    $.confirm({
        title: 'Confirm!',
        content: 'Simple confirm!',
        buttons: {
            confirm: function () {
                $.ajax({
                    type: "POST",
                    url: "/MeetingManagement/DeleteMeetingDecision?id=" + id,
                    data: { MeetingDecisionID: id, MeetingId:0},
            success: function (res) {
                $("#decisionList").html(res)
            }
        })
},
    cancel: function () {
        $("#FormModel").modal("hide");

                    }
                }
            });
}

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
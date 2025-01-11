$.fn.dataTable.pipeline = function (opts) {
  // Configuration options
  var conf = $.extend(
    {
      pages: 5, // number of pages to cache. That means action(url) will be called in 1st, 6th, 11th ... pages
      url: " Users/GetFilteredItems", // url to controller action
      data: null, // function or object with parameters to send to the server
      method: "GET", // Ajax HTTP method
    },
    opts
  );

  // Private variables for storing the cache
  var cacheLower = -1;
  var cacheUpper = null;
  var cacheLastRequest = null;
  var cacheLastJson = null;

  return function (request, drawCallback, settings) {
    var ajax = false;
    var requestStart = request.start;
    var drawStart = request.start;
    var requestLength = request.length;
    var requestEnd = requestStart + requestLength;

    if (settings.clearCache) {
      // API requested that the cache be cleared
      ajax = true;
      settings.clearCache = false;
    } else if (
      cacheLower < 0 ||
      requestStart < cacheLower ||
      requestEnd > cacheUpper
    ) {
      // outside cached data - need to make a request
      ajax = true;
    } else if (
      JSON.stringify(request.order) !==
        JSON.stringify(cacheLastRequest.order) ||
      JSON.stringify(request.columns) !==
        JSON.stringify(cacheLastRequest.columns) ||
      JSON.stringify(request.search) !== JSON.stringify(cacheLastRequest.search)
    ) {
      // properties changed (ordering, columns, searching)
      ajax = true;
    }

    // Store the request for checking next time around
    cacheLastRequest = $.extend(true, {}, request);

    if (ajax) {
      // Need data from the server
      if (requestStart < cacheLower) {
        requestStart = requestStart - requestLength * (conf.pages - 1);

        if (requestStart < 0) {
          requestStart = 0;
        }
      }

      cacheLower = requestStart;
      cacheUpper = requestStart + requestLength * conf.pages;

      request.start = requestStart;
      request.length = requestLength * conf.pages;

      // Provide the same `data` options as DataTables.
      if (typeof conf.data === "function") {
        // As a function it is executed with the data object as an arg
        // for manipulation. If an object is returned, it is used as the
        // data object to submit
        var d = conf.data(request);
        if (d) {
          $.extend(request, d);
        }
      } else if ($.isPlainObject(conf.data)) {
        // As an object, the data given extends the default
        $.extend(request, conf.data);
      }

      settings.jqXHR = $.ajax({
        type: conf.method,
        url: conf.url,
        data: request,
        dataType: "json",
        cache: false,
        // beforeSend: () => $.LoadingOverlay("show"),
        success: function (json) {
          console.log(json);
          cacheLastJson = $.extend(true, {}, json);

          if (cacheLower != drawStart) {
            json.data.splice(0, drawStart - cacheLower);
          }
          if (requestLength >= -1) {
            json.data.splice(requestLength, json.data.length);
          }
          drawCallback(json);
        },
      }).done(function () {
        // $.LoadingOverlay("hide");
      });
    } else {
      json = $.extend(true, {}, cacheLastJson);
      json.draw = request.draw; // Update the echo for each response
      json.data.splice(0, requestStart - cacheLower);
      json.data.splice(requestLength, json.data.length);

      drawCallback(json);
    }
  };
};

// Register an API method that will empty the pipelined data, forcing an Ajax
// fetch on the next draw (i.e. `table.clearPipeline().draw()`)
// Copied from https://datatables.net/examples/server_side/pipeline.html
$.fn.dataTable.Api.register("clearPipeline()", function () {
  return this.iterator("table", function (settings) {
    settings.clearCache = true;
  });
});
//
// DataTables initialisation
// Copied from https://datatables.net/examples/server_side/pipeline.html
// Updated according to our data
//

class MainTable {
  static draw() {
    $("#plannedTable").DataTable({
      processing: true,
      serverSide: true,
      searching: true,
      paging: true,
      ajax: $.fn.dataTable.pipeline({
        url: "/api/production-plan/list",
        pages: 5, //number of pages to cache
      }),

      columns: [
        { data: "tahun", name: "Week" },
        { data: "mingguKe", name: "Week" },
        { 
          data: "senin", 
          render:(data)=>{
            return data[0];
          },
          name: "Senin" },
        { data: "selasa", 
          render:(data)=>{
            return data[0];
          },
          name: "Selsa" },
        { data: "rabu", 
          render:(data)=>{
            return data[0];
          },
          name: "Rabu" },
        { data: "kamis",
          render:(data)=>{
            return data[0];
          },
          name: "kamis" },
        { data: "jumat", 
          render:(data)=>{
            return data[0];
          },
          name: "jumat" },
        { data: "sabtu",
          render:(data)=>{
            return data[0];
          },
          name: "sabtu" },
        { data: "minggu",
          render:(data)=>{
            return data[0];
          },
          name: "minggu" },
      ],
      language: {
        processing: '<div class="spinner"></div>',
        zeroRecords: "No matching records found",
      },
    });


    $("#actualTable").DataTable({
      processing: true,
      serverSide: true,
      searching: true,
      paging: true,
      ajax: $.fn.dataTable.pipeline({
        url: "/api/production-plan/list",
        pages: 5, //number of pages to cache
      }),

      columns: [
        { data: "tahun", name: "Week" },
        { data: "mingguKe", name: "Week" },
        { 
          data: "senin", 
          render:(data)=>{
            return data[1];
          },
          name: "Senin" },
        { data: "selasa", 
          render:(data)=>{
            return data[1];
          },
          name: "Selsa" },
        { data: "rabu", 
          render:(data)=>{
            return data[1];
          },
          name: "Rabu" },
        { data: "kamis",
          render:(data)=>{
            return data[1];
          },
          name: "kamis" },
        { data: "jumat", 
          render:(data)=>{
            return data[1];
          },
          name: "jumat" },
        { data: "sabtu",
          render:(data)=>{
            return data[1];
          },
          name: "sabtu" },
        { data: "minggu",
          render:(data)=>{
            return data[1];
          },
          name: "minggu" },
      ],
      language: {
        processing: '<div class="spinner"></div>',
        zeroRecords: "No matching records found",
      },
    });
  }
}

function createNewUserHandler() {
  console.log("clicked");
  $(".modal-create").modal("show");
}

function SaveNewPlannedHandler() {
  const request = {
    tahun: $("#year").val(), // Get the value from the 'TAHUN' input
    mingguKe: $("#week-option").val(), // Get the value from the 'MINGGU KE' select
    rencanaProduksiHarian: [
      $("#senin").val(),
      $("#selasa").val(),
      $("#rabu").val(),
      $("#kamis").val(),
      $("#jumat").val(),
      $("#sabtu").val(),
      $("#minggu").val(),
    ],
  };

  console.log(request);
  $.ajax({
    method: "POST",
    data: request,
    url: "api/production-plan/add",
    beforeSend: () => {
      $.LoadingOverlay("show");
    },
    success: (response) => {
      $.LoadingOverlay("hide");
      swal(`data has been saved`, {
        icon: "success",
        title: "Register Success",
      }).then(() => {
        window.location.href = "/ProductionPlan"
      });
    },
  })
    .done(() => {
      $.LoadingOverlay("hide");
    })
    .fail((error) => {
      $.LoadingOverlay("hide");
      swal({
        title: `Error ${error.status}`,
        text: error.responseText,
        icon: "error",
      });
    });
}
$(function () {
  MainTable.draw();
  document
    .getElementById("btn-new-plan")
    .addEventListener("click", createNewUserHandler);
  document
    .getElementById("btn-submit-new-plan")
    .addEventListener("click", SaveNewPlannedHandler);

  // Get the select element
  const selectElement = document.getElementById("week-option");
  const numberOfWeeks = 52;
  for (let i = 1; i <= numberOfWeeks; i++) {
    const option = document.createElement("option");
    option.value = i;
    option.text = `Minggu ke-${i}`;
    selectElement.appendChild(option);
  }
});

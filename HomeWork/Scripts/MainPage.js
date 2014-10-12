$(document).ready(function() {

    var successMessage = 'Everything went good!';
    var success = 'success';

    function initModelAndShowWindow(window, title) {
        window.kendoWindow({
            actions: ["Close"],
            draggable: true,
            modal: true,
            pinned: true,
            resizable: true,
            title: title,
            width: 1000,
            height: 550
        });
        var viewModel = null;
        if (title === 'Genres') {
            viewModel = genresViewModel(title);
        } else if (title === 'Actors') {
            viewModel = actorsViewModel(title);
        } else if (title === 'Movies') {
            viewModel = moviesViewModel(title);
        }
        kendo.bind($("#" + title + "Model"), viewModel);
        showWindow(window);
    }

    function showWindow(window) {
        window.data("kendoWindow").center();
        window.data("kendoWindow").open();
    }

    // Menu buttons click
    $('#genresButton').click(function() {
        var genresWindow = $("#GenresWindow");
        initModelAndShowWindow(genresWindow, 'Genres');
    });

    $('#actorsButton').click(function() {
        var actorsWindow = $("#ActorsWindow");
        initModelAndShowWindow(actorsWindow, 'Actors');
    });

    $('#moviesButton').click(function() {
        var moviesWindow = $("#MoviesWindow");
        initModelAndShowWindow(moviesWindow, 'Movies');
    });

    function genresViewModel(title) {
        var failMessage = 'There are movies in this genre. You cannot delete it.';
        var viewModel = kendo.observable({
            GenresDataSource: new kendo.data.DataSource({
                schema: {
                    data: function(data) {
                        if (data === '"error"') {
                            infoViewModel(failMessage);
                            showNotification(failMessage, 'error');
                        } else {
                            showNotification(successMessage, success);
                        }
                        return data;
                    },
                    total: function (data) {
                        return data['odata.count'];
                    },
                    model: {
                        id: "Id",
                        fields: {
                            Id: { editable: false, nullable: true, type: 'number' },
                            Name: { validation: { required: true }, type: 'string' }
                        }
                    }
                },
                batch: false,
                transport: {
                    create: function (options) {
                        action(title + "/Create", options);
                    },
                    read: function (options) {
                        action(title + "/Read", options);
                    },
                    update: function (options) {
                        action(title + "/Update", options);
                    },
                    destroy: function (options) {
                        action(title + "/Destroy", options);
                    },
                    parameterMap: function(options, operation) {
                        if (operation !== "read" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }
                        return options;
                    }
                }
            })
        });
        return viewModel;
    }

    function actorsViewModel(title) {
        var failMessage = 'There are movies with this actor. You cannot delete it.';
        var viewModel = kendo.observable({
            ActorsDataSource: new kendo.data.DataSource({
                schema: {
                    data: function (data) {
                        if (data == "error") {
                            infoViewModel(failMessage);
                            showNotification(failMessage, data);
                        } else {
                            showNotification(successMessage, success);
                        }
                        return data;
                    },
                    total: function(data) {
                        return data['odata.count'];
                    },
                    model: {
                        id: "Id",
                        fields: {
                            Id: { editable: false, nullable: true, type: 'number' },
                            FirstName: { validation: { required: true }, type: 'string' },
                            LastName: { validation: { required: true }, type: 'string' },
                            Gender: { validation: { required: false }, type: 'boolean' },
                            DateOfBirth: { validation: { required: true }, type: 'date', format: '{0:dd.MM.yyyy}' },
                            MoviesList: { validation: { required: false }, editable: false, nullable: true }
                        }
                    }
                },
                batch: false,
                transport: {
                    create: function (options) {
                        options.data.DateOfBirth = convertDate(options.data.DateOfBirth);
                        action(title + "/Create", options);
                    },
                    read: function (options) {
                        action(title + "/Read", options);
                    },
                    update: function (options) {
                        options.data.DateOfBirth = convertDate(options.data.DateOfBirth);
                        action(title + "/Update", options);
                    },
                    destroy: function (options) {
                        action(title + "/Destroy", options);
                    },
                    parameterMap: function(options, operation) {
                        if (operation !== "read" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }
                        return options;
                    }
                }
            })
        });
        return viewModel;
    }

    //TODO: Bug with actors: click "Edit" button - there are not shown chosen actors. 
    //After submitting new actors list, they are shown as 'null', need to reload MovieWindow.
    function moviesViewModel(title) {
        var failMessage = 'Something went wrong.';
        var viewModel = kendo.observable({
            MoviesDataSource: new kendo.data.DataSource({
                data: function(data) {
                    if (data == 'error') {
                        infoViewModel(failMessage);
                        showNotification(failMessage, data);
                    } else {
                        showNotification(successMessage, success);
                    }
                    return data;
                },
                total: function(data) {
                    return data['odata.count'];
                },
                schema: {
                    model: {
                        id: "Id",
                        fields: {
                            Id: { editable: false, nullable: true, type: 'number' },
                            Title: { validation: { required: true }, type: 'string' },
                            Year: { validation: { required: true }, type: 'date', format: '{0:yyyy}' },
                            DurationInSeconds: { validation: { required: true }, type: 'number' },
                            GenreId: { validation: { required: true } },
                            ActorsList: { validation: { required: false } }
                        }
                    }
                },
                batch: false,
                transport: {
                    create: function(options) {
                        options.data.Year = convertDate(options.data.Year);
                        action(title + "/Create", options);
                    },
                    read: function(options) {
                        action(title + "/Read", options);
                    },
                    update: function(options) {
                        options.data.Year = convertDate(options.data.Year);
                        action(title + "/Update", options);
                    },
                    destroy: function(options) {
                        action(title + "/Destroy", options);
                    },
                    parameterMap: function(options, operation) {
                        if (operation !== "read" && options.models) {
                            return { models: kendo.stringify(options.models) };
                        }
                        return options;
                    }
                }
            })
        });
        return viewModel;
    }

    function infoViewModel(text) {
        var infoWindow = $('#infoWindow');
        var viewModel = kendo.observable({
            message: text
        });
        kendo.bind($("#infoWindow"), viewModel);
        infoWindow.kendoWindow({
            actions: ["Close"],
            draggable: false,
            modal: true,
            pinned: true,
            resizable: false,
            title: "Info",
            width: 300,
            height: 200
        });
        showWindow(infoWindow);
    }
    
    function showNotification(text, type) {
        var popupNotification = $("#popupNotification").kendoNotification().data("kendoNotification");
        var d = new Date();
        popupNotification.show(kendo.toString(d, 'HH:MM:ss') + " " + text, type);
    }

    function convertDate(date) {
        var newDate = new Date(date);
        return checkDate(newDate.getDate()) + '.' + checkDate(newDate.getMonth() + 1) + '.' + newDate.getFullYear() + ' 0:00:00';
    }
    
    function action(url, options) {
        $.ajax({
            url: url,
            type: "post",
            dataType: "json",
            data: options.data,
            success: function (result) {
                options.success(result);
            }
        });
    }

});

function checkDate(day) {
    return Number(day) < 10 ? '0' + day : day;
}

function postRequest(controller) {
    var result = null;
    $.ajax({
        url: controller + "/Read",
        async: false,
        dataType: "json",
        type: "post",
        success: function (response) {
            result = response;
        }
    });
    return result;
}

function genresValues() {
    var data = [];
    var response = postRequest('Genres');
    for (var i = 0 ; i < response.length; i++) {
        data.push({ value: response[i].Id, text: response[i].Name });
    }
    return data;
}

function actorsValues() {
    var data = [];
    var response = postRequest('Actors');
    for (var i = 0 ; i < response.length; i++) {
        data.push({ id: response[i].Id, text: response[i].FullName });
    }
    return data;
}

function actorsDisplay(parameters) {
    var result = '';
    var actors = parameters.ActorsList;
    for (var i = 0; i < actors.length; i++) {
        result += actors[i].FirstName + ' ' + actors[i].LastName;
        if (i != actors.length - 1) {
            result += ', ';
        }
    }
    return result;
}

function movieDisplay(parameters) {
    var result = '';
    var movies = parameters.MoviesList;
    if (movies != null) {
        for (var i = 0; i < movies.length; i++) {
            if (movies[i] != null) {
                result += movies[i].Title;
                if (i != movies.length - 1) {
                    result += ', ';
                }
            }
        }
    }
    return result;
}

function actorsEditor(container, options) {
    $('<input data-bind="value:' + options.field + '"/>')
        .appendTo(container)
        .kendoMultiSelect({
            dataTextField: "text",
            dataValueField: "id",
            suggest: true,
            dataSource: actorsValues()
        });
}

function getGender(param) {
    if (param) {
        return "Male";
    } else {
        return "Female";
    }
}

function getDurationHHMMSS(time) {
    var hours = parseInt(Number(time) / 3600);
    var minutes = parseInt((Number(time) / 60) % 60);
    var seconds = parseInt(Number(time) % 60);
    return checkDate(hours) + ":" + checkDate(minutes) + ":" + checkDate(seconds);
}

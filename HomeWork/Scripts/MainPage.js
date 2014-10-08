$(document).ready(function() {

    function initModelAndShowWindow(window, title) {
        window.kendoWindow({
            actions: ["Close"],
            draggable: true,
            modal: true,
            pinned: true,
            resizable: true,
            title: title,
            width: 720,
            height: 700
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
        var successMessage = 'Everything went good!';
        var viewModel = kendo.observable({
            GenresDataSource: new kendo.data.DataSource({
                schema: {
                    data: function(data) {
                        if (data === 'error') {
                            infoViewModel(failMessage);
                            showNotification(failMessage, data);
                            actorsViewModel(title);
                        } else if (data === 'success') {
                            showNotification(successMessage, data);
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
                            Name: { validation: { required: true }, type: 'string' }
                        }
                    }
                },
                batch: false,
                transport: {
                    create: {
                        url: title + "/Create",
                        type: "post"
                    },
                    read: {
                        url: title + "/Read",
                        dataType: "json",
                        type: "post"
                    },
                    update: {
                        url: title + "/Update",
                        type: "post"
                    },
                    destroy: {
                        url: title + "/Destroy",
                        type: "post"
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
        var successMessage = 'Everything went good!';
        var viewModel = kendo.observable({
            ActorsDataSource: new kendo.data.DataSource({
                schema: {
                    data: function(data) {
                        if (data === 'error') {
                            infoViewModel(failMessage);
                            showNotification(failMessage, data);
                            actorsViewModel(title);
                        } else if (data === 'success') {
                            showNotification(successMessage, data);
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
                            DateOfBirth: { validation: { required: true }, type: 'date', format: "{0:yyyy-MM-dd}" }
                        }
                    }
                },
                batch: false,
                transport: {
                    create: {
                        url: title + "/Create",
                        type: "post"
                    },
                    read: {
                        url: title + "/Read",
                        dataType: "json"
                    },
                    update: {
                        url: title + "/Update",
                        type: "post"
                    },
                    destroy: {
                        url: title + "/Destroy",
                        type: "post"
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

    function moviesViewModel(title) {
        var viewModel = kendo.observable({
            MoviesDataSource: new kendo.data.DataSource({
                data: function (data) {
                    return data;
                },
                total: function (data) {
                    return data['odata.count'];
                },
                schema: {
                    model: {
                        id: "Id",
                        fields: {
                            Id: { editable: false, nullable: true, type: 'number' },
                            Title: { validation: { required: true }, type: 'string' },
                            Year: { validation: { required: true }, type: 'date' },
                            DurationInSeconds: { validation: { required: true }, type: 'number' }
                        }
                    }
                },
                batch: false,
                transport: {
                    create: {
                        url: title + "/Create",
                        type: "post"
                    },
                    read: {
                        url: title + "/Read",
                        dataType: "json"
                    },
                    update: {
                        url: title + "/Update",
                        type: "post"
                    },
                    destroy: {
                        url: title + "/Destroy",
                        type: "post"
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

});

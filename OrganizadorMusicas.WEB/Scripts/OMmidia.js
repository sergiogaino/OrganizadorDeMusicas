angular
    .module('OrganizaMusicas', [])
    .controller('OrganizaMusicasController', [
        '$scope',

        function ($scope) {


            $scope.apiUrl = "http://localhost:1916/";

            $scope.midialist = [];
            $scope.artistalist = [];
            $scope.generolist = [];
            $scope.albumlist = [];

          

            $scope.todos = function () {
                $.ajax({
                    type: 'GET',
                    url: $scope.apiUrl + 'api/GetListMidia',
                    success: function (data) {
                        $scope.midialist = data;
                        $scope.artistalist = [];
                        $scope.generolist = [];
                        $scope.albumlist = [];
                        $scope.$apply();
                        $(".btn").attr("class", "btn btn-warning");
                        $("#btnTodos").attr("class", "btn btn-warning active");
                        $("#status1").html("");
                        //console.log($scope.midialist);

                    }
                });
            }
            $scope.genero = function () {
                $.ajax({
                    type: 'GET',
                    url: $scope.apiUrl + 'api/tbGeneroes',
                    success: function (data) {
                        $scope.generolist = data;
                        $scope.midialist = [];
                        $scope.artistalist = [];
                        $scope.albumlist = [];
                        $scope.$apply();
                        $(".btn").attr("class", "btn btn-warning");
                        $("#btnGenero").attr("class", "btn btn-warning active");
                        $("#status1").html("");
                        //console.log($scope.midialist);

                    }
                });
            }
            $scope.artista = function () {
                $.ajax({
                    type: 'GET',
                    url: $scope.apiUrl + 'api/tbArtistas',
                    success: function (data) {
                        $scope.artistalist = data;
                        $scope.midialist = [];
                        $scope.generolist = [];
                        $scope.albumlist = [];
                        $scope.$apply();
                        $(".btn").attr("class", "btn btn-warning");
                        $("#btnArtista").attr("class", "btn btn-warning active");
                        $("#status1").html("");
                        //console.log($scope.midialist);

                    }
                });
            }
            $scope.album = function () {
                $.ajax({
                    type: 'GET',
                    url: $scope.apiUrl + 'api/tbAlbums',
                    success: function (data) {
                        $scope.albumlist = data;
                        $scope.midialist = [];
                        $scope.artistalist = [];
                        $scope.generolist = [];
                        $scope.$apply();
                        $(".btn").attr("class", "btn btn-warning");
                        $("#btnAlbum").attr("class", "btn btn-warning active");
                        $("#status1").html("");
                        //console.log($scope.midialist);

                    }
                });
            }

            $scope.todos();

            $scope.midia = {
                id: '',
                titulo: '',
                ano: '',
                numero: '',
                idGenero: '',
                idAlbum: '',
                idArtista: '',
                Genero: '',
                Album: '',
                Artista: ''
            };
        }
    ]);
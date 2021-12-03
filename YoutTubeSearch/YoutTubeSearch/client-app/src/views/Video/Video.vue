<template>
    <div>
        <div class="page-eventos page-conteudo">
            <div class="banner-top">
                <div class="bg-top" :style="'margin: 0px; background: url(' + video.thumb + ') no-repeat center;'">
                </div>
                <b-container>
                    <div class="img-banner">
                        <img v-bind:src="video.thumb" alt="">
                    </div>
                </b-container>
            </div>


            <section class="evento-selecionado">
                <b-container>
                    <h3 class="title"><b>{{video.name}}</b></h3>
                    <div class="info-eventos">
                        <div class="justify-content-center">
                            <div class="description">

                                <div class="mb-5">
                                    <p class="box-text"> {{video.description}} </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </b-container>
            </section>
        </div>
    </div>
</template>

<style src="./Video.scss" lang="scss"></style>
<script src="./Video.js"></script>
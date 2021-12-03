<template>
  <div>
    <b-container>
      <b-row class="">
        <div class="header-page">
          <h5 class="tit-page">YouTube Searcher</h5>
          <p class="txt-page">Welcome to this project</p>
        </div>
      </b-row>
    </b-container>

    <section class="mb-5">
      <b-container>
        <div class="div-table">
          <div class="header-table">
            <div class="tit-tabela">Search what you want</div>

            <div class="box-pesquisa">
              <div class="box-filtro ml-3">
                <b-form-group>
                  <b-form-input
                  id="login"
                  v-model="login"
                  type="text"
                  required
                  placeholder="Digite o login"></b-form-input>
                </b-form-group>

                <b-form-group class="ml-2">
                  <b-form-input
                  id="nome"
                  v-model="nome"
                  type="text"
                  required
                  placeholder="Digite o nome"></b-form-input>
                </b-form-group>

                <b-form-group class="ml-2">
                  <date-picker
                  id="dataInicio"
                  v-model="dataInicio"
                  :lang="lang"
                  locale="pt-BR"
                  format="DD/MM/YYYY"/>
                </b-form-group>

                <b-form-group class="ml-2">
                  <date-picker
                  id="dataFim"
                  v-model="dataFim"
                  locale="pt-BR"
                  format="DD/MM/YYYY"/>
                </b-form-group>

                <b-form-group class="ml-2">
                  <b-form-checkbox
                  v-model="somentePagos"
                  :value="Boolean(true)"
                  :unchecked-value="Boolean(false)"
                  style="line-height: 100%;"
                  class="">Somente pagos</b-form-checkbox>
                </b-form-group>

                <div class="bt-padrao ml-2">
                  <button class="ml-auto" @click="buscarPedidos(true)" variant="primary">Filtrar</button>
                </div>
              </div>
            </div>
          </div>

          <div class="box-tabel">
            <b-table
              show-empty
              small
              class="table-custom"
              responsive
              :items="pedidos"
              :fields="fields"
              :sort-by.sync="sortBy"
              :sort-desc.sync="sortDesc">
              <template v-slot:cell(login)="data">
                {{ data.value | lowercase }}
              </template>
              <template v-slot:cell(nome)="data">
                {{ data.value | uppercase }}
              </template>
              <template v-slot:cell(valorPedido)="data">
                <div v-if="data.value">
                  {{
                    data.value
                      | number("0.00", {
                        thousandsSeparator: ".",
                        decimalSeparator: ",",
                      })
                  }}
                </div>
              </template>
              <template v-slot:cell(dataPedido)="data">
                <div v-if="data.value">
                  {{ new Date(data.value) | dateFormat("DD/MM/YYYY HH:mm:ss") }}
                </div>
              </template>
              <template v-slot:cell(dataPagamento)="data">
                <div v-if="data.value">
                  {{ new Date(data.value) | dateFormat("DD/MM/YYYY HH:mm:ss") }}
                </div>
              </template>
              <template v-slot:cell(pago)="data" class="text-center">
                <span class="text-center d-block">
                  <font-awesome-icon
                    :class="data.value ? 'text-success' : 'text-danger'"
                    :icon="data.value ? 'thumbs-up' : 'thumbs-down'"
                  />
                </span>
              </template>
            </b-table>
          </div>
        </div>

      </b-container>
    </section>
  </div>
</template>
<script src="./Home.js"></script>
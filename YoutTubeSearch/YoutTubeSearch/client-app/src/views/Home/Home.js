import http from "@/_helper/api-services";
import DatePicker from 'vue2-datepicker';
import './Home.scss';

export default {
    data() {
        const now = new Date();
        const today = new Date(now.getFullYear(), now.getMonth(), now.getDate());
        const minDate = new Date(today);

        minDate.setMonth(minDate.getMonth() - 1);

        return {
            fields: [
                {
                    key: "idUoutube",
                    label: "Youtube Id",
                    sortable: false,
                },
                {
                    key: "name",
                    label: "Name",
                    sortable: false,
                },
                {
                    key: "type",
                    label: "Type",
                    sortable: false,
                },
            ],
            pedidos: [],
            login: null,
            nome: null,
            dataInicio: minDate,
            dataFim: today,
            somentePagos: Boolean(true),
            ordenacaoPor: "dataPagamento",
            sortBy: this.ordenacaoPor,
            sortDesc: true,
            options: [
                { value: null, text: "All" },
                { value: 0, text: "Videos" },
                { value: 1, text: "Channels" },
            ],
        };
    },
    components: {
        DatePicker
    },
    mounted() {
        // this.buscarPedidos(false);
    },
    methods: {
        buscarPedidos(closeCollapse) {
            this.$loading(true);

            var filtros = {
                login: this.login,
                nome: this.nome,
                dataInicio: this.dataInicio,
                dataFim: this.dataFim,
                somentePagos: Boolean(this.somentePagos),
                ordenarPor: this.ordenacaoPor,
            };

            this.sortBy = this.ordenacaoPor;

            http.post("/pedidos/listar-pedidos", filtros).then((response) => {
                this.pedidos = response.data;
                this.$loading(false);

                if (closeCollapse)
                    this.$root.$emit("bv::toggle::collapse", "collapse-filtros");
            }, error => { this.$loading(false); });
        },
    },
};
import http from "@/_helper/api-services";
import DatePicker from 'vue2-datepicker';

export default {
    data() {
        return {
           channel: {}
        };
    },
    components: {
        DatePicker
    },
    async mounted() {
        await this.getDetails();
    },
    watch: {
       
    },
    methods: {
        async getDetails(reset) {
            this.$loading(true);

            await http.get("/Channel/get/" + this.$route.query.id).then((response) => {
                this.channel = response.data;

                this.$loading(false);
            },
            error => 
            { 
                this.$snotify.error(error.response.data.message);
                this.$loading(false);
            });
        },
        formatDate(data) {
            let dateTime = new Date(data);
            return dateTime.toLocaleDateString() + ' ' + dateTime.toLocaleTimeString();
        }
    },
};
export default {
    formatDate(data) {
        let dateTime = new Date(data);
        return dateTime.toLocaleDateString() + ' ' + dateTime.toLocaleTimeString();
    }
};
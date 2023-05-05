import { createApp } from 'vue'
import App from './App.vue'


import PrimeVue from 'primevue/config';
import 'primevue/resources/themes/saga-blue/theme.css'       //theme
import 'primevue/resources/primevue.min.css'        //core css
import 'primeicons/primeicons.css'       //icons


//Components
import ToastService from 'primevue/toastservice';
import DataTable from 'primevue/datatable';
import Button from 'primevue/button';
import Toolbar from 'primevue/toolbar';
import Column from 'primevue/column';
import InputText from 'primevue/inputtext';
import Toast from 'primevue/toast';
import Dialog from 'primevue/dialog';
import RadioButton from 'primevue/radiobutton';

const app = createApp(App);

app.use(ToastService);
app.use(PrimeVue);

app.component("ToastService", ToastService);
app.component("DataTable", DataTable);

app.component("ToolBar", Toolbar);
app.component("ColumnTable", Column);
app.component("InputText", InputText);
app.component("ButtonBase", Button);
app.component('ToastToast', Toast);
app.component('DialogInput', Dialog);
app.component('RadioButton', RadioButton);



app.mount('#app')

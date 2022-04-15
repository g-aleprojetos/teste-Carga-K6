import GetCustomer from "./scenarios/GetCustomer.js";
import { group, sleep } from "k6";

export default function(){
    group('GETCUSTOMER - Controller Customer',() => {
        GetCustomer();
    });

    sleep(1)
}

//rodar k6 run index.js --vus 20 --duration 60s 
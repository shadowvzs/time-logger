import { Container } from "inversify";
import { myContainer } from "../di/container";

export class RootStore {
    public container: Container;

    constructor() {
        this.container = myContainer;
    }
}

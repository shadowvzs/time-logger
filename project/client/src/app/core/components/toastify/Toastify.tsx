import React from "react";
import { StyledToastContainer } from "./styles";

type IAvaliableNotifyTypes = 'success' | 'error' | 'warning' | 'normal';

interface IMessage {
    closeClass: string;
    message: string | HTMLElement;
    onTransitionEnd: (this: GlobalEventHandlers, ev: TransitionEvent) => void;
    type: string;
}

const createMessage = ({ closeClass, message, onTransitionEnd, type }: IMessage) => {
    const elem = document.createElement('div');
    elem.classList.add('notify', type);
    elem.ontransitionend = onTransitionEnd;
    const msgElem = document.createElement('span');
    if (typeof message === 'string') {
        msgElem.textContent = message;
    } else {
        msgElem.appendChild(message);
    }
    const closeElem = document.createElement('div');
    closeElem.classList.add(closeClass);
    closeElem.innerHTML = '✗';
    elem.appendChild(msgElem);
    elem.appendChild(closeElem);
    return elem;
};

export let sendMsg: (type: IAvaliableNotifyTypes, message: string | HTMLElement) => void;

class Notify {
    private container: HTMLDivElement;
    private map = new WeakMap();
    private NOTIFY_DURATION = 2000;
    private LETTER_DURATION_RATIO = 100;
    private CLOSE_CLASS = 'close-notify';
    private TRANSITION_CLASS = 'slidein';

    constructor() {
        sendMsg = this.send.bind(this);
    }

    private onClick = (event: Event): void => {
        const target = event.target as HTMLDivElement;
        if (target.className === this.CLOSE_CLASS) {
            (target.closest('.notify') as HTMLDivElement).classList.remove(this.TRANSITION_CLASS);
        }
    }

    public send(type: IAvaliableNotifyTypes, message: string | HTMLElement): void {
        const messageElem = createMessage({
            type,
            message,
            onTransitionEnd: this.onTransitionEnd,
            closeClass: this.CLOSE_CLASS
        });
        const timer = setTimeout(
            () => this.map.get(messageElem) && messageElem.classList.remove(this.TRANSITION_CLASS),
            this.NOTIFY_DURATION + this.LETTER_DURATION_RATIO * (typeof message === 'string' ? message.length : 10)
        );
        this.map.set(messageElem, timer);
        this.container.appendChild(messageElem);
        setTimeout(() => messageElem.classList.add(this.TRANSITION_CLASS), 100);
    }

    private onTransitionEnd = (event: Event): void => {
        const target = event.target as HTMLDivElement;
        if (target.classList.contains(this.TRANSITION_CLASS)) return;
        target.removeEventListener("transitionend", this.onTransitionEnd);
        this.removeNotify(target as HTMLDivElement);
        this.map.delete(target);
    }

    private removeNotify(elem: HTMLDivElement): void {
        clearTimeout(this.map.get(elem));
        elem.remove();
    }

    public init = (elem: HTMLDivElement): () => void => {
        this.container = elem;
        this.container.addEventListener('click', this.onClick);
        return this.dispose;
    }

    public dispose = (): void => {
        this.container.removeEventListener('click', this.onClick);
    }
}

export const ToastContainer = () => {

    const ref = React.useRef<HTMLDivElement>(null);
    const store = React.useMemo(() => new Notify(), []);
    React.useEffect(() => store.init(ref.current!), [ref, store]);

    return (
        <StyledToastContainer className='notify-container' ref={ref} />
    );
}
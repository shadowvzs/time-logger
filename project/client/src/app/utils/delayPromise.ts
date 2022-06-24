export const delayPromise = (rangeStart: number, rangeEnd?: number) => {
    const delay = rangeEnd ? (Math.random() * (rangeEnd - rangeStart) + rangeStart) : rangeStart;
    return new Promise((resolve) => {
        setTimeout(resolve, delay);
    });
};
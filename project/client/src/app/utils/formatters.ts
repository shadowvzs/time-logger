export function minuteDurationFormatter(minutesSpent: number): string {
    const resultArr: string[] = [];
    const hours = Math.floor(minutesSpent / 60);
    const minutes = minutesSpent % 60;
    if (hours) {
        resultArr.push(hours + 'h');
    }

    if (!hours || minutes) {
        resultArr.push(minutes + 'm');
    }
    return resultArr.join(' ');
}

export function dateFormatter(date: Date | string): string {
    if (!date) { return '-'; }
    const strDate = typeof date === 'string' ? date : date.toISOString();
    return strDate.substring(0, 16).replace('T', ' ') || '';
}
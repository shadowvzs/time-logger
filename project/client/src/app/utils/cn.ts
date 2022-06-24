export function cn(...args: (string | false)[]): string {
    return args.filter(Boolean).join(' ');
}
shader_type canvas_item;

uniform vec4 grey_color : source_color = vec4(0.5, 0.5, 0.5, 1.0);

void fragment() {
    vec4 tex_color = texture(TEXTURE, UV);
    
    // If the pixel is pure black (RGB = 0,0,0), change it to grey
    if (tex_color.r == 0.0 && tex_color.g == 0.0 && tex_color.b == 0.0) {
        COLOR = vec4(grey_color.rgb, tex_color.a);
    } else {
        COLOR = tex_color; // Keep the background exactly as it is
    }
}
